using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameSaveManager
{
    public static string currentStory = string.Empty;

    public static void Load()
    {
        currentStory = PlayerPrefs.GetString(currentStory);
    }

    public static void Save(string saved)
    {
        PlayerPrefs.SetString(currentStory, saved);
    }
}
