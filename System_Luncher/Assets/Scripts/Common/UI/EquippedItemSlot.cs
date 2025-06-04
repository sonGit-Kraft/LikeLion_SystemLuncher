// �ڷ�ƾ ���� ���̺귯�� ���
using System.Collections;
// �÷��� ���� ���̺귯�� ���
using System.Collections.Generic;
// ���ڿ� ó���� ���� StringBuilder ���
using System.Text;
// Unity �⺻ ���̺귯�� ���
using UnityEngine;
// Unity UI ������Ʈ ���
using UnityEngine.UI;

// ������ ������ ���� Ŭ���� - MonoBehaviour�� ��ӹ���
public class EquippedItemSlot : MonoBehaviour
{
    // �߰� ������ �̹��� ������Ʈ (�������� ���� �� ǥ��)
    public Image AddIcon;
    // ������ ������ ������ �̹��� ������Ʈ
    public Image EquippedItemIcon;

    // ������ ������ ������ ��� ����
    private UserItemData m_EquippedItemData;

    // �������� �����ϴ� �޼���
    public void SetItem(UserItemData userItemData)
    {
        // ���޹��� ������ ������ ����
        m_EquippedItemData = userItemData;

        // �߰� ������ ��Ȱ��ȭ
        AddIcon.gameObject.SetActive(false);
        // ������ ������ ������ Ȱ��ȭ
        EquippedItemIcon.gameObject.SetActive(true);

        // ������ ID�� ���ڿ��� ��ȯ�Ͽ� StringBuilder ����
        StringBuilder sb = new StringBuilder(m_EquippedItemData.ItemId.ToString());
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
            EquippedItemIcon.sprite = Sprite.Create(itemIconTexture, new Rect(0, 0, itemIconTexture.width, itemIconTexture.height), new Vector2(1f, 1f));
        }
    }

    // �������� �����ϴ� �޼���
    public void ClearItem()
    {
        // ������ ������ ������ �ʱ�ȭ
        m_EquippedItemData = null;

        // �߰� ������ Ȱ��ȭ
        AddIcon.gameObject.SetActive(true);
        // ������ ������ ������ ��Ȱ��ȭ
        EquippedItemIcon.gameObject.SetActive(false);
    }

    // ������ ������ ���� Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnClickEquippedItemSlot()
    {
        // ���ο� ��� UI ������ ����
        var uiData = new EquipmentUIData();
        // �ø��� ��ȣ ����
        uiData.SerialNumber = m_EquippedItemData.SerialNumber;
        // ������ ID ����
        uiData.ItemId = m_EquippedItemData.ItemId;
        // ���� ���� �÷��� ���� (������)
        uiData.IsEquipped = true;
        // ��� UI ����
        UIManager.Instance.OpenUI<EquipmentUI>(uiData);
    }
}