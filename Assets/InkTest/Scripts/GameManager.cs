using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using VNCreator;

public class GameManager : MonoBehaviour
{
    [Header("Start")]
    public GameObject nameSetScreen;
    public GameObject dressScreen;
    public GameObject storyScreen;
    public InputField playerName;
    public Button nameSubmitBtn;
    public Button startStoryBtn;

    [Header("Dialogue")]
    public GameObject dialoguePanel;
    public Text message;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            // Если еще нет экземпляра класса, создаем его
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                // Если объект GameManager не найден в сцене, создадим новый пустой объект
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Appearance.ToString()))
            PlayerPrefs.SetInt(ItemsDatabase.Category.Appearance.ToString(), 0);

        if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Dress.ToString()))
            PlayerPrefs.SetInt(ItemsDatabase.Category.Dress.ToString(), 0);

        if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Hair.ToString()))
            PlayerPrefs.SetInt(ItemsDatabase.Category.Hair.ToString(), 0);

        if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Accessories.ToString()))
            PlayerPrefs.SetInt(ItemsDatabase.Category.Accessories.ToString(), 0);

        nameSubmitBtn.onClick.AddListener(SubmitName);
        startStoryBtn.onClick.AddListener(StartStory);

        storyScreen.SetActive(false);
    }

    private void SubmitName()
    {
        if (playerName.text.Length > 0)
        {
            PlayerPrefs.SetString("PlayerName", playerName.text);
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", "Кейт");
        }

        dialoguePanel.SetActive(true);
        Animator dialogueAnim = dialoguePanel.GetComponent<Animator>();
        dialogueAnim.Play("middle");
        StartCoroutine(TypeSentence("Перед началом истории выберите, как будет выглядеть ваша героиня."));
    }

    private void StartStory()
    {
        dialoguePanel.SetActive(true);
        storyScreen.SetActive(true);
        dressScreen.SetActive(false);
    }


    public IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }
        yield return null;
    }
}
