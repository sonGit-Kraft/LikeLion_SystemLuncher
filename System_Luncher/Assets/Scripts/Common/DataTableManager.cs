using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ������ ���̺��� �����ϴ� �̱��� �Ŵ��� Ŭ����
public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    private const string DATA_PATH = "DataTable"; // ������ ���̺� ���� ���

    private const string CHAPTER_DATA_TABLE = "ChapterDataTable"; // é�� ������ ���̺� ���ϸ�
    private List<ChapterData> ChapterDataTable = new List<ChapterData>(); // é�� ������ ����Ʈ

    // �ʱ�ȭ �Լ�
    protected override void Init()
    {
        base.Init(); // �θ� Ŭ���� �ʱ�ȭ ȣ��

        LoadChapterDataTable(); // é�� ������ ���̺� �ε�
    }

    // é�� ������ ���̺� �ε� �Լ�
    private void LoadChapterDataTable()
    {
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}"); // CSV ���� �б�

        foreach (var data in parsedDataTable) // �Ľ̵� �����͸� ��ȸ
        {
            var chapterData = new ChapterData // �� é�� ������ ��ü ����
            {
                ChapterNo = Convert.ToInt32(data["chapter_no"]), // é�� ��ȣ ����
                TotalStages = Convert.ToInt32(data["total_stages"]), // �� �������� �� ����
                ChapterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]), // é�� Ŭ���� ���� ���� ����
                ChapterRewardGold = Convert.ToInt32(data["chapter_reward_gold"]), // é�� Ŭ���� ���� ��� ����
            };

            ChapterDataTable.Add(chapterData); // ����Ʈ�� é�� ������ �߰�
        }
    }

    // Ư�� é�� ��ȣ�� �����͸� ��ȯ�ϴ� �Լ�
    public ChapterData GetChapterData(int chapterNo)
    {
        return ChapterDataTable.Where(item => item.ChapterNo == chapterNo).FirstOrDefault(); // LINQ�� é�� ��ȣ�� �ش��ϴ� ������ �˻� �� ��ȯ
    }

    // ������ ������ ���� ���� ����
    #region ITEM_DATA
    // ������ ������ ���̺� ���ϸ� ���
    private const string ITEM_DATA_TABLE = "ItemDataTable";
    // ������ ������ ����Ʈ
    private List<ItemData> ItemDataTable = new List<ItemData>();

    // ������ ������ ���̺� �ε� �޼���
    private void LoadItemDataTable()
    {
        // CSV ������ �о �Ľ̵� ������ ��������
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{ITEM_DATA_TABLE}");

        // �Ľ̵� ������ ��ȸ
        foreach (var data in parsedDataTable)
        {
            // ������ ������ ��ü ����
            var itemData = new ItemData
            {
                // ������ ID ����
                ItemId = Convert.ToInt32(data["item_id"]),
                // ������ �̸� ����
                ItemName = data["item_name"].ToString(),
                // ���ݷ� ����
                AttackPower = Convert.ToInt32(data["attack_power"]),
                // ���� ����
                Defense = Convert.ToInt32(data["defense"]),
            };

            // ������ �����͸� ����Ʈ�� �߰�
            ItemDataTable.Add(itemData);
        }
    }

    // Ư�� ������ ID�� ������ ������ ��������
    public ItemData GetItemData(int itemId)
    {
        // LINQ�� ����Ͽ� �ش� ������ ID�� ������ ��ȯ
        return ItemDataTable.Where(item => item.ItemId == itemId).FirstOrDefault();
    }
    // ������ ������ ���� ���� ��
    #endregion
}

// é�� ������ Ŭ����
public class ChapterData
{
    public int ChapterNo; // é�� ��ȣ
    public int TotalStages; // �� �������� ��
    public int ChapterRewardGem; // é�� Ŭ���� ���� ����
    public int ChapterRewardGold; // é�� Ŭ���� ���� ���
}

// ������ ������ Ŭ����
public class ItemData
{
    // ������ ID
    public int ItemId;
    // ������ �̸�
    public string ItemName;
    // ���ݷ�
    public int AttackPower;
    // ����
    public int Defense;
}

// ������ Ÿ�� ������
public enum ItemType
{
    // ����
    Weapon = 1,
    // ����
    Shield,
    // �䰩
    ChestArmor,
    // �尩
    Gloves,
    // ����
    Boots,
    // �Ǽ�����
    Accessory
}

// ������ ��� ������
public enum ItemGrade
{
    // �Ϲ�
    Common = 1,
    // ���
    Uncommon,
    // ���
    Rare,
    // ����
    Epic,
    // ����
    Legendary,
}
