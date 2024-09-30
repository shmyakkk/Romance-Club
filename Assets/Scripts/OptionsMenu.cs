using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public Toggle musicActiveToggle;

    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider readSpeedSlider;
    public Toggle instantTextToggle;
    public Button backButton;

    [Header("Copy Objects")]
    public TMP_Text textToCopy;
    public Button copyButton;

    [Header("Social Media")]
    public Button tgButton;
    public Button vkButton;

    [Header("Menu Objects")]
    public GameObject optionsMenu;
    public GameObject mainMenu;

    void Start()
    {
        GameOptions.InitilizeOptions();

        if (musicActiveToggle != null)
        {
            musicActiveToggle.isOn = GameOptions.musicActive;
            musicActiveToggle.onValueChanged.AddListener(GameOptions.SetMusicActiveVolume);
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = GameOptions.musicVolume;
            musicVolumeSlider.onValueChanged.AddListener(GameOptions.SetMusicVolume);
        }
        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.value = GameOptions.sfxVolume;
            sfxVolumeSlider.onValueChanged.AddListener(GameOptions.SetSFXVolume);
        }
        if (readSpeedSlider != null)
        {
            readSpeedSlider.value = GameOptions.readSpeed;
            readSpeedSlider.onValueChanged.AddListener(GameOptions.SetReadingSpeed);
        }
        if (instantTextToggle != null)
        {
            instantTextToggle.isOn = GameOptions.isInstantText;
            instantTextToggle.onValueChanged.AddListener(GameOptions.SetInstantText);
        }


        backButton.onClick.AddListener(Back);
        copyButton.onClick.AddListener(CopyToClipboard);
        tgButton.onClick.AddListener(TgOpenLink);
        vkButton.onClick.AddListener(VkOpenLink);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void CopyToClipboard()
    {
        string text = textToCopy.text;
        GUIUtility.systemCopyBuffer = text;
    }
    public void TgOpenLink()
    {
        Application.OpenURL("https://t.me/telegram");
    }
    public void VkOpenLink()
    {
        Application.OpenURL("https://vk.com");
    }
}
