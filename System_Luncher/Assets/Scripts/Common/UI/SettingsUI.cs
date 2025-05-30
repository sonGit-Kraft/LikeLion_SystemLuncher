// TextMeshPro UI ������Ʈ�� ����ϱ� ���� ���ӽ����̽�
using TMPro;
// Unity ������ �⺻ ����� ����ϱ� ���� ���ӽ����̽�
using UnityEngine;

// ���� UI�� �����ϴ� Ŭ����, BaseUI�� ��ӹ���
public class SettingsUI : BaseUI
{
    // ���� ������ ǥ���� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI GameVersionTxt;
    // ���� ���� ���¸� ��Ÿ���� ��� ������Ʈ
    public GameObject SoundOnToggle;
    // ���� ���� ���¸� ��Ÿ���� ��� ������Ʈ
    public GameObject SoundOffToggle;

    // ��������ó����ħ URL ���
    private const string PRIVACY_POLICY_URL = "https://likelion.net/";

    // UI ������ �����ϴ� �޼��� �������̵�
    public override void SetInfo(BaseUIData uiData)
    {
        // �θ� Ŭ������ SetInfo �޼��� ȣ��
        base.SetInfo(uiData);

        // ���� ���� ����
        SetGameVersion();

        // ����� ���� �����͸� ������
        var userSettingsData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        // ����� ���� �����Ͱ� �����ϴ��� Ȯ��
        if (userSettingsData != null)
        {
            // ���� ������ UI�� �ݿ�
            SetSoundSetting(userSettingsData.Sound);
        }
    }

    // ���� ������ �����ϴ� �޼���
    private void SetGameVersion()
    {
        // ���ø����̼� ������ �ؽ�Ʈ�� ����
        GameVersionTxt.text = $"Version:{Application.version}";
    }

    // ���� ���� ���¸� UI�� �ݿ��ϴ� �޼���
    private void SetSoundSetting(bool sound)
    {
        // ���� ���� ����� Ȱ��ȭ ���� ����
        SoundOnToggle.SetActive(sound);
        // ���� ���� ����� Ȱ��ȭ ���� ���� (�ݴ�)
        SoundOffToggle.SetActive(!sound);
    }

    // ���� ���� ��� Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnClickSoundOnToggle()
    {
        // �α� ���
        Logger.Log($"{GetType()}::OnClickSoundOnToggle");

        // ��ư Ŭ�� ȿ���� ���
        AudioManager.Instance.PlaySFX(SFX.ui_button_click);

        // ����� ���� �����͸� ������
        var userSettingsData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        // ����� ���� �����Ͱ� �����ϴ��� Ȯ��
        if (userSettingsData != null)
        {
            // ���带 �������� ����
            userSettingsData.Sound = false;
            // ����� ������ ����
            UserDataManager.Instance.SaveUserData();
            // ����� ���Ұ�
            AudioManager.Instance.Mute();
            // UI�� ���� ���� �ݿ�
            SetSoundSetting(userSettingsData.Sound);
        }
    }

    // ���� ���� ��� Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnClickSoundOffToggle()
    {
        // �α� ���
        Logger.Log($"{GetType()}::OnClickSoundOffToggle");

        // ��ư Ŭ�� ȿ���� ���
        AudioManager.Instance.PlaySFX(SFX.ui_button_click);

        // ����� ���� �����͸� ������
        var userSettingsData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        // ����� ���� �����Ͱ� �����ϴ��� Ȯ��
        if (userSettingsData != null)
        {
            // ���带 �������� ����
            userSettingsData.Sound = true;
            // ����� ������ ����
            UserDataManager.Instance.SaveUserData();
            // ����� ���Ұ� ����
            AudioManager.Instance.UnMute();
            // UI�� ���� ���� �ݿ�
            SetSoundSetting(userSettingsData.Sound);
        }
    }

    // ��������ó����ħ ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnClickPrivacyPolicyBtn()
    {
        // �α� ���
        Logger.Log($"{GetType()}::OnClickPrivacyPolicyBtn");

        // ��ư Ŭ�� ȿ���� ���
        AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        // ��������ó����ħ URL�� ���������� ����
        Application.OpenURL(PRIVACY_POLICY_URL);
    }
}