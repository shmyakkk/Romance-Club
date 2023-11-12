using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextAsset inkFile;

    [SerializeField] private Text diamonds;

    [Header("Buttons")]
    public Button playBtn;
    public Button startNewGameBtn;
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

        if (playBtn != null)
        {
            if (PlayerPrefs.HasKey("Story_1"))
                playBtn.onClick.AddListener(LoadGame);
            else
                playBtn.onClick.AddListener(NewGame);
        }
        if (startNewGameBtn != null)
        {
            startNewGameBtn.onClick.AddListener(NewGame);
        }
        if (optionsMenuBtn != null)
            optionsMenuBtn.onClick.AddListener(DisplayOptionsMenu);
        if (storeMenuBtn != null)
            storeMenuBtn.onClick.AddListener(DisplayStoreMenu);
        if (quitBtn != null)
            quitBtn.onClick.AddListener(Quit);
    }

    void NewGame()
    {
        GameSaveManager.currentStory = inkFile.text;

        sceneLoader.SetActive(true);
        mainMenu.SetActive(false);

        sceneLoader.GetComponent<SceneLoading>().LoadScene(playScene);
    }

    void LoadGame()
    {
        GameSaveManager.Load();

        sceneLoader.SetActive(true);
        mainMenu.SetActive(false);

        sceneLoader.GetComponent<SceneLoading>().LoadScene(playScene);
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
