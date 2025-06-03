// GPM UI ���ӽ����̽� ���
using Gpm.Ui;
// TextMeshPro ���ӽ����̽� ���
using TMPro;
using UnityEngine;

// �κ��丮 UI Ŭ���� (BaseUI ���)
public class InventoryUI : BaseUI
{ 
    // �κ��丮 ��ũ�� ����Ʈ ������Ʈ
    public InfiniteScroll InventoryScrollList;

    // UI ���� ���� �޼��� (�θ� Ŭ���� �������̵�)
    public override void SetInfo(BaseUIData uiData)
    {
        // �θ� Ŭ������ SetInfo ȣ��
        base.SetInfo(uiData);

        // �κ��丮 ���� �޼��� ȣ��
        SetInventory();
    }

    // �κ��丮 ���� �޼���
    private void SetInventory()
    {
        // �κ��丮 ��ũ�� ����Ʈ �ʱ�ȭ
        InventoryScrollList.Clear();

        // ���� �κ��丮 ������ ��������
        var userInventoryData = UserDataManager.Instance.GetUserData<UserInventoryData>();
        // ���� �κ��丮 �����Ͱ� �����ϴ� ���
        if (userInventoryData != null)
        {
            // �κ��丮 ������ ������ ����Ʈ ��ȸ
            foreach (var itemData in userInventoryData.InventoryItemDataList)
            {
                // ������ ���� ������ ��ü ����
                var itemSlotData = new InventoryItemSlotData();
                // �ø��� ��ȣ ����
                itemSlotData.SerialNumber = itemData.SerialNumber;
                // ������ ID ����
                itemSlotData.ItemId = itemData.ItemId;
                // ��ũ�� ����Ʈ�� ������ ������ �߰�
                InventoryScrollList.InsertData(itemSlotData);
            }
        }
    }
}