// Unity ���� ���ӽ����̽� ���
using UnityEngine;
// Unity ������ ���ӽ����̽� ���
using UnityEditor;

// Unity �����Ϳ����� �����ϵǴ� ���Ǻ� ������ ���ù�
#if UNITY_EDITOR
// Unity ������ Ŀ���� ���� Ŭ����
public class CustomTools : Editor
{
    // ���� ���� 10�� �߰��ϴ� �޴� ������
    [MenuItem("Inflearn/Add User Gem (+10)")]
    // ���� �� �߰� �޼���
    public static void AddUserGem()
    {
        // PlayerPrefs���� �� ���� ���ڿ��� �����ͼ� long Ÿ������ ��ȯ
        var Gem = long.Parse(PlayerPrefs.GetString("Gem"));
        // �� ���� 10 �߰�
        Gem += 10;

        // ������Ʈ�� �� ���� ���ڿ��� ��ȯ�Ͽ� PlayerPrefs�� ����
        PlayerPrefs.SetString("Gem", Gem.ToString());
        // PlayerPrefs ���� ������ ��ũ�� ��� ����
        PlayerPrefs.Save();
    }

    // ���� ��带 100�� �߰��ϴ� �޴� ������
    [MenuItem("Inflearn/Add User Gold (+100)")]
    // ���� ��� �߰� �޼���
    public static void AddUserGold()
    {
        // PlayerPrefs���� ��� ���� ���ڿ��� �����ͼ� long Ÿ������ ��ȯ
        var Gold = long.Parse(PlayerPrefs.GetString("Gold"));
        // ��� ���� 100 �߰�
        Gold += 100;

        // ������Ʈ�� ��� ���� ���ڿ��� ��ȯ�Ͽ� PlayerPrefs�� ����
        PlayerPrefs.SetString("Gold", Gold.ToString());
        // PlayerPrefs ���� ������ ��ũ�� ��� ����
        PlayerPrefs.Save();
    }
}
// Unity ������ ���Ǻ� ������ ���ù� ����
#endif