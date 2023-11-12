﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text diamonds;

    [Header("Buttons")]
    public Button playBtn;
    public Button restartBtn;
    public Button optionsMenuBtn;
    public Button storeMenuBtn;
    public Button quitBtn;

    [Header("")]
    public string playScene;

    [Header("Menu Objects")]
    public GameObject storeMenu;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject sceneLoader;

    private void Awake()
    {
        diamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
    }

    void Start()
    {
        PlayerPrefs.SetInt("Diamonds", 100);

        if (!PlayerPrefs.HasKey("Story"))
            PlayerPrefs.SetString("Story", "");

        if (playBtn != null)
            playBtn.onClick.AddListener(Play);

        if (optionsMenuBtn != null)
            optionsMenuBtn.onClick.AddListener(DisplayOptionsMenu);

        if (storeMenuBtn != null)
            storeMenuBtn.onClick.AddListener(DisplayStoreMenu);

        if (quitBtn != null)
            quitBtn.onClick.AddListener(Quit);

        if (restartBtn != null)
            restartBtn.onClick.AddListener(Restart);
    }

    void Play()
    {
        sceneLoader.SetActive(true);
        mainMenu.SetActive(false);

        sceneLoader.GetComponent<SceneLoading>().LoadScene(playScene);
    }

    void Restart()
    {
        PlayerPrefs.SetString("Story", "");
        PlayerPrefs.SetInt("Professionalism", 0);
        PlayerPrefs.SetInt("Scandal", 0);
        //сброс текста и ачивок
    }

    void DisplayOptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    void DisplayStoreMenu()
    {
        storeMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    void Quit()
    {
        Application.Quit();
    }
}
