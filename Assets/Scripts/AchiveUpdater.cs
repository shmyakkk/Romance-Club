using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchiveUpdater : MonoBehaviour
{
    [SerializeField] private Text diamonds;

    [SerializeField] private Text achive1;
    [SerializeField] private Text achive2;
    [SerializeField] private Text achive3;

    [SerializeField] private Text chapterNumber;

    private void Awake()
    {
        SetParameters();
    }

    public void SetParameters()
    {
        if (!PlayerPrefs.HasKey("Diamonds"))
            PlayerPrefs.SetInt("Diamonds", 50);

        if (!PlayerPrefs.HasKey("Professionalism"))
            PlayerPrefs.SetInt("Professionalism", 0);

        if (!PlayerPrefs.HasKey("Scandal"))
            PlayerPrefs.SetInt("Scandal", 0);


        diamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();

        achive1.text = PlayerPrefs.GetInt("Professionalism").ToString();
        achive2.text = PlayerPrefs.GetInt("Scandal").ToString();
        achive3.text = "0";


        if (!PlayerPrefs.HasKey("Chapter"))
        {
            PlayerPrefs.SetInt("Chapter", 1);
        }

        if (chapterNumber != null)
            chapterNumber.text = PlayerPrefs.GetInt("Chapter").ToString() + " серия из 12";
    }
    
}
