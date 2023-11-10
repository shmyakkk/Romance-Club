using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Toggle musicActiveToggle;
    public GameObject musicManager;

    void Start()
    {
        if (musicActiveToggle != null)
        {
            musicActiveToggle.isOn = GameOptions.musicActive;
            musicActiveToggle.onValueChanged.AddListener(GameOptions.SetMusicActiveVolume);
            musicActiveToggle.onValueChanged.AddListener(musicManager.GetComponent<MusicManager>().UpdateMusicActive);
        }
    }
}
