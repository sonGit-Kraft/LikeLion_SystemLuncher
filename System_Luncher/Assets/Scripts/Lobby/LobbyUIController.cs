using UnityEngine;

// �κ� UI�� �����ϴ� ��Ʈ�ѷ� Ŭ����
public class LobbyUIController : MonoBehaviour
{
    // �ʱ�ȭ �޼���
    public void Init()
    {
        UIManager.Instance.EnableStatsUI(true);
    }

    // �� �����Ӹ��� ȣ��Ǵ� ������Ʈ �޼���
    private void Update()
    {
        // �Է� ó�� �޼��� ȣ��
        HandleInput();
    }

    // ����� �Է��� ó���ϴ� �޼���
    private void HandleInput()
    {
        // ESC Ű�� ���ȴٰ� ������ ��
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // UI ��ư Ŭ�� ȿ���� ���
            AudioManager.Instance.PlaySFX(SFX.ui_button_click);

            // ���� �ֻ����� �ִ� UI ��������
            var frontUI = UIManager.Instance.GetCurrentFrontUI();
            // �����ִ� UI�� ������
            if (frontUI)
            {
                // �ش� UI �ݱ�
                frontUI.CloseUI();
            }
            // �����ִ� UI�� ������
            else
            {
                // Ȯ�� â ������ ����
                var uiData = new ConfirmUIData();
                // Ȯ�� â Ÿ���� OK/Cancel�� ����
                uiData.ConfirmType = ConfirmType.OK_CANCEL;
                // ���� �ؽ�Ʈ ����
                uiData.TitleTxt = "Quit";
                // ���� �ؽ�Ʈ ����
                uiData.DescTxt = "Do you want to quit game?";
                // OK ��ư �ؽ�Ʈ ����
                uiData.OKBtnTxt = "Quit";
                // Cancel ��ư �ؽ�Ʈ ����
                uiData.CancelBtnTxt = "Cancel";
                // OK ��ư Ŭ�� �� ������ �׼� ����
                uiData.OnClickOKBtn = () =>
                {
                    // ���� ����
                    Application.Quit();
                };
                // Ȯ�� â UI ����
                UIManager.Instance.OpenUI<ConfirmUI>(uiData);
            }
        }
    }

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnClickSettingsBtn()
    {
        // �α� ���
        Logger.Log($"{GetType()}::OnClickSettingsBtn");

        // �⺻ UI ������ ����
        var uiData = new BaseUIData();
        // ���� UI ����
        UIManager.Instance.OpenUI<SettingsUI>(uiData);
    }

    public void OnClickProfileBtn()
    {
        Logger.Log($"{GetType()}::OnClickProfileBtn");

        var uiData = new BaseUIData();
        UIManager.Instance.OpenUI<InventoryUI>(uiData);
    }
}
