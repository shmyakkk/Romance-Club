using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    public static bool musicActive = true;


    public static float musicVolume = 0.5f;
    public static float sfxVolume = 0.5f;
    public static float readSpeed = 2f;
    public static bool isInstantText = false;


    public static void InitilizeOptions()
    {
        if (PlayerPrefs.HasKey("MusicActive"))
            musicActive = PlayerPrefs.GetInt("MusicActive") == 1 ? true : false;

        if (PlayerPrefs.HasKey("MusicVolume"))
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        if (PlayerPrefs.HasKey("SfxVolume"))
            sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
        if (PlayerPrefs.HasKey("ReadSpeed"))
            readSpeed = PlayerPrefs.GetFloat("ReadSpeed");
        if (PlayerPrefs.HasKey("InstantText"))
            isInstantText = PlayerPrefs.GetInt("InstantText") == 1 ? true : false;
    }

    public static void SetMusicActiveVolume(bool index)
    {
        musicActive = index;
        PlayerPrefs.SetInt("MusicActive", index ? 1 : 0);
    }

    public static void SetMusicVolume(float index)
    {
        musicVolume = index;
        PlayerPrefs.SetFloat("MusicVolume", index);
    }

    public static void SetSFXVolume(float index)
    {
        sfxVolume = index;
        PlayerPrefs.SetFloat("SfxVolume", index);
    }

    public static void SetReadingSpeed(float index)
    {
        readSpeed = index;
        PlayerPrefs.SetFloat("ReadSpeed", index);
    }

    public static void SetInstantText(bool index)
    {
        isInstantText = index;
        PlayerPrefs.SetInt("InstantText", index ? 1 : 0);
    }
}
