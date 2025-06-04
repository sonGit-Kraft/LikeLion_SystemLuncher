// ���ڿ� ó���� ���� StringBuilder ���
using System.Text;
// TextMeshPro �ؽ�Ʈ ������Ʈ ���
using TMPro;
// Unity �⺻ ���̺귯�� ���
using UnityEngine;
// Unity UI ������Ʈ ���
using UnityEngine.UI;

// ��� UI ������ Ŭ���� - BaseUIData�� ��ӹ���
public class EquipmentUIData : BaseUIData
{
    // ������ �ø��� ��ȣ
    public long SerialNumber;
    // ������ ID
    public int ItemId;
    public bool IsEquipped;
}

// ��� UI Ŭ���� - BaseUI�� ��ӹ���
public class EquipmentUI : BaseUI
{
    // ������ ��� ��� �̹��� ������Ʈ
    public Image ItemGradeBg;
    // ������ ������ �̹��� ������Ʈ
    public Image ItemIcon;
    // ������ ��� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI ItemGradeTxt;
    // ������ �̸� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI ItemNameTxt;
    // ���ݷ� ��ġ �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI AttackPowerAmountTxt;
    // ���� ��ġ �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI DefenseAmountTxt;

    // ��� UI ������ ��� ����
    private EquipmentUIData m_EquipmentUIData;

    // UI ������ �����ϴ� �޼��� �������̵�
    public override void SetInfo(BaseUIData uiData)
    {
        // �θ� Ŭ������ SetInfo �޼��� ȣ��
        base.SetInfo(uiData);

        // UI �����͸� EquipmentUIData�� ĳ����
        m_EquipmentUIData = uiData as EquipmentUIData;
        // ĳ���� ���� �� ���� ó��
        if (m_EquipmentUIData == null)
        {
            // ���� �α� ���
            Logger.LogError("m_EquipmentUIData is invalid.");
            // �޼��� ����
            return;
        }

        // ������ ID�� ������ ������ ��������
        var itemData = DataTableManager.Instance.GetItemData(m_EquipmentUIData.ItemId);
        // ������ �����Ͱ� ���� ��� ���� ó��
        if (itemData == null)
        {
            // ���� �α� ��� (������ ID ����)
            Logger.LogError($"Item data is invalid. ItemId:{m_EquipmentUIData.ItemId}");
            // �޼��� ����
            return;
        }

        // ������ ID���� ��� ���� ���� (õ�� �ڸ� ����)
        var itemGrade = (ItemGrade)((m_EquipmentUIData.ItemId / 1000) % 10);
        // ��޿� �´� ��� �ؽ�ó �ε�
        var gradeBgTexture = Resources.Load<Texture2D>($"Textures/{itemGrade}");
        // ��� �ؽ�ó�� �����ϴ� ���
        if (gradeBgTexture != null)
        {
            // �ؽ�ó�� ��������Ʈ �����Ͽ� ��� �̹����� ����
            ItemGradeBg.sprite = Sprite.Create(gradeBgTexture, new Rect(0, 0, gradeBgTexture.width, gradeBgTexture.height), new Vector2(1f, 1f));
        }

        // ������ ��� �ؽ�Ʈ ����
        ItemGradeTxt.text = itemGrade.ToString();
        // ��޺� ���� �ڵ带 ������ ����
        var hexColor = string.Empty;
        // ������ ��޿� ���� ���� �б� ó��
        switch (itemGrade)
        {
            // �Ϲ� ����� ���
            case ItemGrade.Common:
                // �Ķ��� ����
                hexColor = "#1AB3FF";
                break;
            // ��� ����� ���
            case ItemGrade.Uncommon:
                // �ʷϻ� ����
                hexColor = "#51C52C";
                break;
            // ��� ����� ���
            case ItemGrade.Rare:
                // ��ȫ�� ����
                hexColor = "#EA5AFF";
                break;
            // ���� ����� ���
            case ItemGrade.Epic:
                // ��Ȳ�� ����
                hexColor = "#FF9900";
                break;
            // ���� ����� ���
            case ItemGrade.Legendary:
                // ������ ����
                hexColor = "#F24949";
                break;
            // �⺻ ���̽� (ó�� ����)
            default:
                break;
        }

        // ���� ��ȯ�� ���� ����
        Color color;
        // Hex ���� �ڵ带 Color�� ��ȯ �õ�
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            // ��ȯ ���� �� ��� �ؽ�Ʈ ���� ����
            ItemGradeTxt.color = color;
        }

        // ������ ID�� ���ڿ��� ��ȯ�Ͽ� StringBuilder ����
        StringBuilder sb = new StringBuilder(m_EquipmentUIData.ItemId.ToString());
        // �� ��° �ڸ� ���ڸ� '1'�� ���� (�����ܿ� ID ����)
        sb[1] = '1';
        // ������ �̸����� ����� ���ڿ� ����
        var itemIconName = sb.ToString();

        // ������ �ؽ�ó �ε�
        var itemIconTexture = Resources.Load<Texture2D>($"Textures/{itemIconName}");
        // ������ �ؽ�ó�� �����ϴ� ���
        if (itemIconTexture != null)
        {
            // �ؽ�ó�� ��������Ʈ �����Ͽ� ������ �̹����� ����
            ItemIcon.sprite = Sprite.Create(itemIconTexture, new Rect(0, 0, itemIconTexture.width, itemIconTexture.height), new Vector2(1f, 1f));
        }

        // ������ �̸� �ؽ�Ʈ ����
        ItemNameTxt.text = itemData.ItemName;
        // ���ݷ� ��ġ �ؽ�Ʈ ���� (+ ��ȣ ����)
        AttackPowerAmountTxt.text = $"+{itemData.AttackPower}";
        // ���� ��ġ �ؽ�Ʈ ���� (+ ��ȣ ����)
        DefenseAmountTxt.text = $"+{itemData.Defense}";
    }
}