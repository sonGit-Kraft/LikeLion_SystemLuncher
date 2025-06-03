// �ý��� ���ӽ����̽� ���
using System;
// �ý��� �÷��� ���ӽ����̽� ���
using System.Collections;
// �ý��� �÷��� ���׸� ���ӽ����̽� ���
using System.Collections.Generic;
// Unity ���� ���ӽ����̽� ���
using UnityEngine;

// ����ȭ ������ Ŭ������ ����
[Serializable]
// ���� ������ ������ Ŭ����
public class UserItemData
{
    // ���� �ø��� ��ȣ (����ũ ��)
    public long SerialNumber; //unique value
    // ������ ID
    public int ItemId;

    // ���� ������ ������ ������
    public UserItemData(long serialNumber, int itemId)
    {
        // �ø��� ��ȣ ����
        SerialNumber = serialNumber;
        // ������ ID ����
        ItemId = itemId;
    }
}

// JSONUtility�� ����Ͽ� JSON���� �Ľ��ϱ� ���� ���� Ŭ����
//wrapper class to parse data to JSON using JSONUtility
// ����ȭ ������ Ŭ������ ����
[Serializable]
// ���� �κ��丮 ������ ������ ����Ʈ ���� Ŭ����
public class UserInventoryItemDataListWrapper
{
    // �κ��丮 ������ ������ ����Ʈ
    public List<UserItemData> InventoryItemDataList;
}

// ���� �κ��丮 ������ Ŭ���� (IUserData �������̽� ����)
public class UserInventoryData : IUserData
{
    // �κ��丮 ������ ������ ����Ʈ ������Ƽ (�⺻��: �� ����Ʈ)
    public List<UserItemData> InventoryItemDataList { get; set; } = new List<UserItemData>();

    // �⺻ ������ ���� �޼���
    public void SetDefaultData()
    {
        // �α� ���
        Logger.Log($"{GetType()}::SetDefaultData");

        // �ø��� ��ȣ => DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4") 
        //serial number => DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4") 
        // �⺻ �����۵��� �κ��丮�� �߰� (�ø��� ��ȣ�� ���� �ð� + ���� 4�ڸ� ���ڷ� ����)
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11001));
        // ������ 11002 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11002));
        // ������ 21001 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 21001));
        // ������ 21002 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 21002));
        // ������ 31001 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 31001));
        // ������ 31002 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 31002));
        // ������ 41001 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 41001));
        // ������ 41002 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 41002));
        // ������ 51001 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 51001));
        // ������ 51002 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 51002));
        // ������ 61001 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 61001));
        // ������ 61002 �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 61002));
    }

    // ������ �ε� �޼���
    public bool LoadData()
    {
        // �α� ���
        Logger.Log($"{GetType()}::LoadData");

        // ��� ���� �ʱ�ȭ
        bool result = false;

        // ���� ó�� ����
        try
        {
            // PlayerPrefs���� �κ��丮 ������ ������ ����Ʈ JSON ���ڿ� ��������
            string inventoryItemDataListJson = PlayerPrefs.GetString("InventoryItemDataList");
            // JSON ���ڿ��� null�̰ų� ������� ������
            if (!string.IsNullOrEmpty(inventoryItemDataListJson))
            {
                // JSON�� UserInventoryItemDataListWrapper ��ü�� ��ȯ
                UserInventoryItemDataListWrapper itemDataListWrapper = JsonUtility.FromJson<UserInventoryItemDataListWrapper>(inventoryItemDataListJson);
                // ���ۿ��� ���� ������ ����Ʈ ��������
                InventoryItemDataList = itemDataListWrapper.InventoryItemDataList;

                // �α� ���
                Logger.Log("InventoryItemDataList");
                // �κ��丮 �����۵� ��ȸ�ϸ� �α� ���
                foreach (var item in InventoryItemDataList)
                {
                    // �� �������� �ø��� ��ȣ�� ������ ID �α� ���
                    Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
                }
            }

            // �ε� ����
            result = true;
        }
        // ���� �߻� �� ó��
        catch (System.Exception e)
        {
            // �ε� ���� �α� ���
            Logger.Log("Load failed (" + e.Message + ")");
        }

        // ��� ��ȯ
        return result;
    }

    // ������ ���� �޼���
    public bool SaveData()
    {
        // �α� ���
        Logger.Log($"{GetType()}::SaveData");

        // ��� ���� �ʱ�ȭ
        bool result = false;

        // ���� ó�� ����
        try
        {
            // �κ��丮 ������ ������ ����Ʈ ���� ��ü ����
            UserInventoryItemDataListWrapper inventoryItemDataListWrapper = new UserInventoryItemDataListWrapper();
            // ���ۿ� �κ��丮 ������ ������ ����Ʈ ����
            inventoryItemDataListWrapper.InventoryItemDataList = InventoryItemDataList;
            // ���� ��ü�� JSON ���ڿ��� ��ȯ
            string inventoryItemDataListJson = JsonUtility.ToJson(inventoryItemDataListWrapper);
            // PlayerPrefs�� JSON ���ڿ� ����
            PlayerPrefs.SetString("InventoryItemDataList", inventoryItemDataListJson);

            // �α� ���
            Logger.Log("InventoryItemDataList");
            // �κ��丮 �����۵� ��ȸ�ϸ� �α� ���
            foreach (var item in InventoryItemDataList)
            {
                // �� �������� �ø��� ��ȣ�� ������ ID �α� ���
                Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
            }

            // PlayerPrefs ����
            PlayerPrefs.Save();
            // ���� ����
            result = true;
        }
        // ���� �߻� �� ó��
        catch (System.Exception e)
        {
            // ���� ���� �α� ��� (�޽����� �߸� ǥ�õ� - "Load failed"�� �ƴ� "Save failed"���� ��)
            Logger.Log("Load failed (" + e.Message + ")");
        }

        // ��� ��ȯ
        return result;
    }
}