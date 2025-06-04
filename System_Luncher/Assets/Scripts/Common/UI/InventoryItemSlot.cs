// GPM UI ���ӽ����̽� ���
using Gpm.Ui;
// Unity ���� ���ӽ����̽� ���
using UnityEngine;
// Unity UI ���ӽ����̽� ���
using UnityEngine.UI;
// �ý��� ���ӽ����̽� ���
using System;
// �ý��� �ؽ�Ʈ ���ӽ����̽� ���
using System.Text;

// �κ��丮 ������ ���� ������ Ŭ���� (InfiniteScrollData ���)
public class InventoryItemSlotData : InfiniteScrollData
{
    // ������ �ø��� ��ȣ
    public long SerialNumber;
    // ������ ID
    public int ItemId;
}

// �κ��丮 ������ ���� Ŭ���� (InfiniteScrollItem ���)
public class InventoryItemSlot : InfiniteScrollItem
{
    // ������ ��� ��� �̹���
    public Image ItemGradeBg;
    // ������ ������ �̹���
    public Image ItemIcon;

    // �κ��丮 ������ ���� ������ ��� ����
    private InventoryItemSlotData m_InventoryItemSlotData;

    // ������ ������Ʈ �޼��� (�θ� Ŭ���� �������̵�)
    public override void UpdateData(InfiniteScrollData scrollData)
    {
        // �θ� Ŭ������ UpdateData ȣ��
        base.UpdateData(scrollData);

        // ��ũ�� �����͸� InventoryItemSlotData�� ĳ����
        m_InventoryItemSlotData = scrollData as InventoryItemSlotData;
        // ĳ���õ� �����Ͱ� null�� ���
        if (m_InventoryItemSlotData == null)
        {
            // ���� �α� ���
            Logger.LogError("m_InventoryItemSlotData is invalid.");
            // �޼��� ����
            return;
        }

        // ������ ID���� ��� ���� ���� (õ�� �ڸ� ���ڸ� ItemGrade ���������� ��ȯ)
        var itemGrade = (ItemGrade)((m_InventoryItemSlotData.ItemId / 1000) % 10);
        // ��޿� ���� ��� �ؽ�ó �ε�
        var gradeBgTexture = Resources.Load<Texture2D>($"Textures/{itemGrade}");
        // ��� �ؽ�ó�� �����ϴ� ���
        if (gradeBgTexture != null)
        {
            // �ؽ�ó�� ��������Ʈ�� ��ȯ�Ͽ� ��� �̹����� ����
            ItemGradeBg.sprite = Sprite.Create(gradeBgTexture, new Rect(0, 0, gradeBgTexture.width, gradeBgTexture.height), new Vector2(1f, 1f));
        }

        // ������ ID ���ڿ��� StringBuilder�� ��ȯ
        StringBuilder sb = new StringBuilder(m_InventoryItemSlotData.ItemId.ToString());
        // �� ��° �ڸ� ���ڸ� '1'�� ���� (������ �̸� ��Ģ)
        sb[1] = '1';
        // ����� ���ڿ��� ������ ������ �̸����� ���
        var itemIconName = sb.ToString();

        // ������ ������ �ؽ�ó �ε�
        var itemIconTexture = Resources.Load<Texture2D>($"Textures/{itemIconName}");
        // ������ �ؽ�ó�� �����ϴ� ���
        if (itemIconTexture != null)
        {
            // �ؽ�ó�� ��������Ʈ�� ��ȯ�Ͽ� ������ �̹����� ����
            ItemIcon.sprite = Sprite.Create(itemIconTexture, new Rect(0, 0, itemIconTexture.width, itemIconTexture.height), new Vector2(1f, 1f));
        }
    }

    public void OnClickInventoryItemSlot()
    {
        var uiData = new EquipmentUIData();
        uiData.SerialNumber = m_InventoryItemSlotData.SerialNumber;
        uiData.ItemId = m_InventoryItemSlotData.ItemId;
        UIManager.Instance.OpenUI<EquipmentUI>(uiData);
    }
}