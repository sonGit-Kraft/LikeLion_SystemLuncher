using System; // System ���ӽ����̽� ���
using TMPro; // TextMeshPro ���ӽ����̽� ���
using UnityEngine.UI; // Unity UI ���ӽ����̽� ���

public enum ConfirmType // Ȯ��â Ÿ�� ������
{
    OK, // Ȯ�� ��ư�� �ִ� Ÿ��
    OK_CANCEL // Ȯ�ΰ� ��� ��ư�� ��� �ִ� Ÿ��
}
public class ConfirmUIData : BaseUIData // BaseUIData�� ��ӹ޴� Ȯ��â UI ������ Ŭ����
{
    public ConfirmType ConfirmType; // Ȯ��â Ÿ��
    public string TitleTxt; // ���� �ؽ�Ʈ
    public string DescTxt; // ���� �ؽ�Ʈ
    public string OKBtnTxt; // Ȯ�� ��ư �ؽ�Ʈ
    public Action OnClickOKBtn; // Ȯ�� ��ư Ŭ�� �� ������ �׼�
    public string CancelBtnTxt; // ��� ��ư �ؽ�Ʈ
    public Action OnClickCancelBtn; // ��� ��ư Ŭ�� �� ������ �׼�
}

public class ConfirmUI : BaseUI
{
    public TextMeshProUGUI TitleTxt = null; // ���� �ؽ�Ʈ UI ������Ʈ
    public TextMeshProUGUI DescTxt = null; // ���� �ؽ�Ʈ UI ������Ʈ
    public Button OKBtn = null; // Ȯ�� ��ư UI ������Ʈ
    public Button CancelBtn = null; // ��� ��ư UI ������Ʈ
    public TextMeshProUGUI OKBtnTxt = null; // Ȯ�� ��ư �ؽ�Ʈ UI ������Ʈ
    public TextMeshProUGUI CancelBtnTxt = null; // ��� ��ư �ؽ�Ʈ UI ������Ʈ

    private ConfirmUIData m_ConfirmUIData = null; // Ȯ��â UI ������ ���� ����
    private Action m_OnClickOKBtn = null; // Ȯ�� ��ư Ŭ�� �׼� ���� ����
    private Action m_OnClickCancelBtn = null; // ��� ��ư Ŭ�� �׼� ���� ����

    public override void SetInfo(BaseUIData uiData) // UI ���� ���� �޼��� �������̵�
    {
        base.SetInfo(uiData); // �θ� Ŭ������ SetInfo ȣ��

        m_ConfirmUIData = uiData as ConfirmUIData; // BaseUIData�� ConfirmUIData�� ĳ����

        TitleTxt.text = m_ConfirmUIData.TitleTxt; // ���� �ؽ�Ʈ ����
        DescTxt.text = m_ConfirmUIData.DescTxt; // ���� �ؽ�Ʈ ����
        OKBtnTxt.text = m_ConfirmUIData.OKBtnTxt; // Ȯ�� ��ư �ؽ�Ʈ ����
        m_OnClickOKBtn = m_ConfirmUIData.OnClickOKBtn; // Ȯ�� ��ư Ŭ�� �׼� ����
        CancelBtnTxt.text = m_ConfirmUIData.CancelBtnTxt; // ��� ��ư �ؽ�Ʈ ����
        m_OnClickCancelBtn = m_ConfirmUIData.OnClickCancelBtn; // ��� ��ư Ŭ�� �׼� ����

        OKBtn.gameObject.SetActive(true); // Ȯ�� ��ư Ȱ��ȭ
        CancelBtn.gameObject.SetActive(m_ConfirmUIData.ConfirmType == ConfirmType.OK_CANCEL); // Ȯ��â Ÿ���� OK_CANCEL�� ��쿡�� ��� ��ư Ȱ��ȭ
    }

    public void OnClickOKBtn() // Ȯ�� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    {
        m_OnClickOKBtn?.Invoke(); // Ȯ�� ��ư Ŭ�� �׼� ����
        CloseUI(); // UI �ݱ�
    }

    public void OnClickCancelBtn() // ��� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    {
        m_OnClickCancelBtn?.Invoke(); // ��� ��ư Ŭ�� �׼� ����
        CloseUI(); // UI �ݱ�
    }
}
