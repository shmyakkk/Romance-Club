using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Buttons")]
        public Button newGameBtn;
        public Button continueBtn;
        public Button optionsMenuBtn;
        public Button storeMenuBtn;
        public Button quitBtn;

        [Header("")]
        [Scene]
        public string playScene;

        [Header("Menu Objects")]
        public GameObject storeMenu;
        public GameObject optionsMenu;
        public GameObject mainMenu;
        public GameObject sceneLoader;

        void Start()
        {
            if(newGameBtn != null)
                newGameBtn.onClick.AddListener(NewGame);
            if(optionsMenuBtn != null)
                optionsMenuBtn.onClick.AddListener(DisplayOptionsMenu);
            if (storeMenuBtn != null)
                storeMenuBtn.onClick.AddListener(DisplayStoreMenu);
            if (quitBtn != null)
                quitBtn.onClick.AddListener(Quit);
            if (continueBtn != null)
            {
                if (PlayerPrefs.HasKey("MainGame"))
                    continueBtn.onClick.AddListener(LoadGame);
                else
                    continueBtn.interactable = false;
            }
        }

        void NewGame()
        {
            GameSaveManager.NewLoad("MainGame");
            //SceneManager.LoadScene(playScene, LoadSceneMode.Single);
            sceneLoader.SetActive(true);
            mainMenu.SetActive(false);

            sceneLoader.GetComponent<SceneLoading>().LoadScene(playScene);
        }

        void LoadGame()
        {
            GameSaveManager.currentLoadName = "MainGame";
            SceneManager.LoadScene(playScene, LoadSceneMode.Single);
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
}
