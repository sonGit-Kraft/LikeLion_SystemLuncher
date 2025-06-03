// TextMeshPro ���ӽ����̽� ���
using TMPro;
// Unity ���� ���ӽ����̽� ���
using UnityEngine;

// ���� ��ȭ ������ ǥ���ϴ� UI Ŭ����
public class GoodsUI : MonoBehaviour
{
    // ��� ������ ǥ���ϴ� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI GoldAmountTxt;
    // �� ������ ǥ���ϴ� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI GemAmountTxt;

    // ��ȭ ������ �����ϴ� �޼���
    public void SetValues()
    {
        // ���� ��ȭ ������ ��������
        var userGoodData = UserDataManager.Instance.GetUserData<UserGoodsData>();
        // ���� ��ȭ �����Ͱ� ������
        if (userGoodData == null)
        {
            // ���� �α� ���
            Logger.LogError("No user goods data.");
            // �޼��� ����
            return;
        }

        // ��� ������ õ���� �޸� �������� �ؽ�Ʈ�� ����
        GoldAmountTxt.text = userGoodData.Gold.ToString("N0");
        // �� ������ õ���� �޸� �������� �ؽ�Ʈ�� ����
        GemAmountTxt.text = userGoodData.Gem.ToString("N0");
    }
}
