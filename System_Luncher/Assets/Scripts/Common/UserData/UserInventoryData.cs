// �ý��� ���� ���̺귯�� ���
using System;
// �ڷ�ƾ ���� ���̺귯�� ���
using System.Collections;
// �÷��� ���� ���̺귯�� ���
using System.Collections.Generic;
// Unity �⺻ ���̺귯�� ���
using UnityEngine;

// ����ȭ ������ Ŭ������ ����
[Serializable]
// ����� ������ ������ Ŭ����
public class UserItemData
{
    // ������ �ø��� ��ȣ
    public long SerialNumber; //unique value
    // ������ ID
    public int ItemId;

    // ����� ������ ������ ������
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
[Serializable]
// ����� �κ��丮 ������ ������ ����Ʈ ���� Ŭ����
public class UserInventoryItemDataListWrapper
{
    // �κ��丮 ������ ������ ����Ʈ
    public List<UserItemData> InventoryItemDataList;
}

// ����� �κ��丮 ������ Ŭ���� - IUserData �������̽� ����
public class UserInventoryData : IUserData
{
    // ������ ���� ������ ������Ƽ
    public UserItemData EquippedWeaponData { get; set; }
    // ������ ���� ������ ������Ƽ
    public UserItemData EquippedShieldData { get; set; }
    // ������ ���� �� ������ ������Ƽ
    public UserItemData EquippedChestArmorData { get; set; }
    // ������ ���� ������ ������Ƽ
    public UserItemData EquippedBootsData { get; set; }
    // ������ �尩 ������ ������Ƽ
    public UserItemData EquippedGlovesData { get; set; }
    // ������ �׼����� ������ ������Ƽ
    public UserItemData EquippedAccessoryData { get; set; }

    // �κ��丮 ������ ������ ����Ʈ ������Ƽ (�� ����Ʈ�� �ʱ�ȭ)
    public List<UserItemData> InventoryItemDataList { get; set; } = new List<UserItemData>();

    // �⺻ �����͸� �����ϴ� �޼���
    public void SetDefaultData()
    {
        // �α� ���
        Logger.Log($"{GetType()}::SetDefaultData");

        // �ø��� ��ȣ ���� ���: ���� ��¥�ð�(yyyyMMddHHmmss) + ���� 4�ڸ� ����
        //serial number => DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4") 

        // ������ ID 11001�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11001));
        // ������ ID 11002�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11002));
        // ������ ID 22001�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 22001));
        // ������ ID 22002�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 22002));
        // ������ ID 33001�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 33001));
        // ������ ID 33002�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 33002));
        // ������ ID 44001�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 44001));
        // ������ ID 44002�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 44002));
        // ������ ID 55001�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 55001));
        // ������ ID 55002�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 55002));
        // ������ ID 65001�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 65001));
        // ������ ID 65002�� ������ ������ �߰�
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 65002));

        // ù ��° �������� ����� ����
        EquippedWeaponData = new UserItemData(InventoryItemDataList[0].SerialNumber, InventoryItemDataList[0].ItemId);
        // �� ��° �������� ���з� ����
        EquippedShieldData = new UserItemData(InventoryItemDataList[2].SerialNumber, InventoryItemDataList[2].ItemId);
    }

    // �����͸� �ε��ϴ� �޼���
    public bool LoadData()
    {
        // �α� ���
        Logger.Log($"{GetType()}::LoadData");

        // ��� ���� �ʱ�ȭ
        bool result = false;

        // ���� ó�� ����
        try
        {
            // PlayerPrefs���� ������ ���� ������ JSON ��������
            string weaponJson = PlayerPrefs.GetString("EquippedWeaponData");
            // JSON ���ڿ��� ������� ���� ���
            if (!string.IsNullOrEmpty(weaponJson))
            {
                // JSON�� UserItemData ��ü�� ��ȯ
                EquippedWeaponData = JsonUtility.FromJson<UserItemData>(weaponJson);
                // �α� ���
                Logger.Log($"EquippedWeaponData: SN:{EquippedWeaponData.SerialNumber} ItemId:{EquippedWeaponData.ItemId}");
            }

            // PlayerPrefs���� ������ ���� ������ JSON ��������
            string shieldJson = PlayerPrefs.GetString("EquippedShieldData");
            // JSON ���ڿ��� ������� ���� ���
            if (!string.IsNullOrEmpty(shieldJson))
            {
                // JSON�� UserItemData ��ü�� ��ȯ
                EquippedShieldData = JsonUtility.FromJson<UserItemData>(shieldJson);
                // �α� ���
                Logger.Log($"EquippedShieldData: SN:{EquippedShieldData.SerialNumber} ItemId:{EquippedShieldData.ItemId}");
            }

            // PlayerPrefs���� ������ ���� �� ������ JSON ��������
            string chestArmorJson = PlayerPrefs.GetString("EquippedChestArmorData");
            // JSON ���ڿ��� ������� ���� ���
            if (!string.IsNullOrEmpty(chestArmorJson))
            {
                // JSON�� UserItemData ��ü�� ��ȯ
                EquippedChestArmorData = JsonUtility.FromJson<UserItemData>(chestArmorJson);
                // �α� ���
                Logger.Log($"EquippedChestArmorData: SN:{EquippedChestArmorData.SerialNumber} ItemId:{EquippedChestArmorData.ItemId}");
            }

            // PlayerPrefs���� ������ ���� ������ JSON ��������
            string bootsJson = PlayerPrefs.GetString("EquippedBootsData");
            // JSON ���ڿ��� ������� ���� ���
            if (!string.IsNullOrEmpty(bootsJson))
            {
                // JSON�� UserItemData ��ü�� ��ȯ
                EquippedBootsData = JsonUtility.FromJson<UserItemData>(bootsJson);
                // �α� ���
                Logger.Log($"EquippedBootsArmorData: SN:{EquippedBootsData.SerialNumber} ItemId:{EquippedBootsData.ItemId}");
            }

            // PlayerPrefs���� ������ �尩 ������ JSON ��������
            string glovesJson = PlayerPrefs.GetString("EquippedGlovesData");
            // JSON ���ڿ��� ������� ���� ���
            if (!string.IsNullOrEmpty(glovesJson))
            {
                // JSON�� UserItemData ��ü�� ��ȯ
                EquippedGlovesData = JsonUtility.FromJson<UserItemData>(glovesJson);
                // �α� ���
                Logger.Log($"EquippedGlovesData: SN:{EquippedGlovesData.SerialNumber} ItemId:{EquippedGlovesData.ItemId}");
            }

            // PlayerPrefs���� ������ �׼����� ������ JSON ��������
            string accessoryJson = PlayerPrefs.GetString("EquippedAccessoryData");
            // JSON ���ڿ��� ������� ���� ���
            if (!string.IsNullOrEmpty(accessoryJson))
            {
                // JSON�� UserItemData ��ü�� ��ȯ
                EquippedAccessoryData = JsonUtility.FromJson<UserItemData>(accessoryJson);
                // �α� ���
                Logger.Log($"EquippedChestArmorData: SN:{EquippedAccessoryData.SerialNumber} ItemId:{EquippedAccessoryData.ItemId}");
            }

            // PlayerPrefs���� �κ��丮 ������ ������ ����Ʈ JSON ��������
            string inventoryItemDataListJson = PlayerPrefs.GetString("InventoryItemDataList");
            // JSON ���ڿ��� ������� ���� ���
            if (!string.IsNullOrEmpty(inventoryItemDataListJson))
            {
                // JSON�� ���� ��ü�� ��ȯ
                UserInventoryItemDataListWrapper itemDataListWrapper = JsonUtility.FromJson<UserInventoryItemDataListWrapper>(inventoryItemDataListJson);
                // ���ۿ��� ���� ����Ʈ ������ ����
                InventoryItemDataList = itemDataListWrapper.InventoryItemDataList;

                // �κ��丮 ������ ����Ʈ �α� ���
                Logger.Log("InventoryItemDataList");
                // ��� ������ �����͸� ��ȸ�ϸ� �α� ���
                foreach (var item in InventoryItemDataList)
                {
                    // �� �������� �ø��� ��ȣ�� ID �α� ���
                    Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
                }
            }

            // �ε� �������� ����
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

    // �����͸� �����ϴ� �޼���
    public bool SaveData()
    {
        // �α� ���
        Logger.Log($"{GetType()}::SaveData");

        // ��� ���� �ʱ�ȭ
        bool result = false;

        // ���� ó�� ����
        try
        {
            // ���� �����͸� JSON���� ��ȯ
            string weaponJson = JsonUtility.ToJson(EquippedWeaponData);
            // PlayerPrefs�� ���� ������ ����
            PlayerPrefs.SetString("EquippedWeaponData", weaponJson);
            // ���� �����Ͱ� null�� �ƴ� ���
            if (EquippedWeaponData != null)
            {
                // �α� ���
                Logger.Log($"EquippedWeaponData: SN:{EquippedWeaponData.SerialNumber} ItemId:{EquippedWeaponData.ItemId}");
            }

            // ���� �����͸� JSON���� ��ȯ
            string shieldJson = JsonUtility.ToJson(EquippedShieldData);
            // PlayerPrefs�� ���� ������ ����
            PlayerPrefs.SetString("EquippedShieldData", shieldJson);
            // ���� �����Ͱ� null�� �ƴ� ���
            if (EquippedShieldData != null)
            {
                // �α� ���
                Logger.Log($"EquippedShieldData: SN:{EquippedShieldData.SerialNumber} ItemId:{EquippedShieldData.ItemId}");
            }

            // ���� �� �����͸� JSON���� ��ȯ
            string chestArmorJson = JsonUtility.ToJson(EquippedChestArmorData);
            // PlayerPrefs�� ���� �� ������ ����
            PlayerPrefs.SetString("EquippedChestArmorData", chestArmorJson);
            // ���� �� �����Ͱ� null�� �ƴ� ���
            if (EquippedChestArmorData != null)
            {
                // �α� ���
                Logger.Log($"EquippedChestArmorData: SN:{EquippedChestArmorData.SerialNumber} ItemId:{EquippedChestArmorData.ItemId}");
            }

            // ���� �����͸� JSON���� ��ȯ
            string bootsJson = JsonUtility.ToJson(EquippedBootsData);
            // PlayerPrefs�� ���� ������ ����
            PlayerPrefs.SetString("EquippedBootsData", bootsJson);
            // ���� �����Ͱ� null�� �ƴ� ���
            if (EquippedBootsData != null)
            {
                // �α� ���
                Logger.Log($"EquippedBootsData: SN:{EquippedBootsData.SerialNumber} ItemId:{EquippedBootsData.ItemId}");
            }

            // �尩 �����͸� JSON���� ��ȯ
            string glovesJson = JsonUtility.ToJson(EquippedGlovesData);
            // PlayerPrefs�� �尩 ������ ����
            PlayerPrefs.SetString("EquippedGlovesData", glovesJson);
            // �尩 �����Ͱ� null�� �ƴ� ���
            if (EquippedGlovesData != null)
            {
                // �α� ���
                Logger.Log($"EquippedGlovesData: SN:{EquippedGlovesData.SerialNumber} ItemId:{EquippedGlovesData.ItemId}");
            }

            // �׼����� �����͸� JSON���� ��ȯ
            string accessoryJson = JsonUtility.ToJson(EquippedAccessoryData);
            // PlayerPrefs�� �׼����� ������ ����
            PlayerPrefs.SetString("EquippedAccessoryData", accessoryJson);
            // �׼����� �����Ͱ� null�� �ƴ� ���
            if (EquippedAccessoryData != null)
            {
                // �α� ���
                Logger.Log($"EquippedAccessoryData: SN:{EquippedAccessoryData.SerialNumber} ItemId:{EquippedAccessoryData.ItemId}");
            }

            // �κ��丮 ������ ������ ����Ʈ ���� ��ü ����
            UserInventoryItemDataListWrapper inventoryItemDataListWrapper = new UserInventoryItemDataListWrapper();
            // ���ۿ� �κ��丮 ������ ������ ����Ʈ ����
            inventoryItemDataListWrapper.InventoryItemDataList = InventoryItemDataList;
            // ���۸� JSON���� ��ȯ
            string inventoryItemDataListJson = JsonUtility.ToJson(inventoryItemDataListWrapper);
            // PlayerPrefs�� �κ��丮 ������ ������ ����Ʈ ����
            PlayerPrefs.SetString("InventoryItemDataList", inventoryItemDataListJson);

            // �κ��丮 ������ ����Ʈ �α� ���
            Logger.Log("InventoryItemDataList");
            // ��� ������ �����͸� ��ȸ�ϸ� �α� ���
            foreach (var item in InventoryItemDataList)
            {
                // �� �������� �ø��� ��ȣ�� ID �α� ���
                Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
            }
            // PlayerPrefs ���� ����
            PlayerPrefs.Save();

            // ���� �������� ����
            result = true;
        }
        // ���� �߻� �� ó��
        catch (System.Exception e)
        {
            // ���� ���� �α� ���
            Logger.Log("Load failed (" + e.Message + ")");
        }

        // ��� ��ȯ
        return result;
    }
}