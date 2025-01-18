using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : BaseSingleton<ResourceManager>
{
    public int Diamonds { 
        get => PlayerPrefs.GetInt("diamonds");
        set
        {
            Diamonds = PlayerPrefs.GetInt("diamonds");
            PlayerPrefs.SetInt("Diamonds", value);
        }
    }
}
