using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStory : MonoBehaviour
{
    [Header("Screens")]
    public GameObject startedScreen;
    public GameObject dressScreen;
    public GameObject UI;
    public GameObject bgScreen;
    public GameObject dressBG;
    public GameObject storyBG;

    [Header("Interraction")]
    public InputField playerName;
    public Button nameSubmitBtn;
    public Button dressBtn;
    public Button continueBtn;
    public Button startStoryBtn;
    public Button nextButton;

    [Header("Scripts")]
    public StoryManager storyManager;
    public DialogueManager dialogueManager;
    public CharacterManager characterManager;
    public Fader fader;

    private void Start()
    {
        if (PlayerPrefs.GetString("Story") == "")
        {
            PlayerPrefs.SetInt("Professionalism", 0);
            PlayerPrefs.SetInt("Scandal", 0);

            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Appearance.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Appearance.ToString(), 0);

            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Dress.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Dress.ToString(), 0);

            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Hair.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Hair.ToString(), 0);

            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Accessories.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Accessories.ToString(), 0);

            nameSubmitBtn.onClick.AddListener(SubmitName);
            dressBtn.onClick.AddListener(OpenDress);
            continueBtn.onClick.AddListener(Continue);
            startStoryBtn.onClick.AddListener(Fade);

            dressScreen.SetActive(false);
            bgScreen.SetActive(true);
            startedScreen.SetActive(true);
            dressBtn.gameObject.SetActive(false);
            dressBG.SetActive(false);

            dialogueManager.SetDialogueActive(false);
        }
        else
        {
            dressScreen.SetActive(false);
            bgScreen.SetActive(false);
            dressBtn.gameObject.SetActive(false);
            dressBG.SetActive(false);

            dialogueManager.SetDialogueActive(true);

            characterManager.CurrentName = "..";
            characterManager.SetCharacter("base");

            StartPlot();
        }
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

        startedScreen.SetActive(false);
        dialogueManager.Show("..", "Перед началом истории выберите, как будет выглядеть ваша героиня.");
        dressBtn.gameObject.SetActive(true);
    }

    private void OpenDress()
    {
        dressScreen.SetActive(true);
        dialogueManager.SetDialogueActive(false);
        dressBG.SetActive(true);
    }

    private void Continue()
    {
        UI.SetActive(true);

        dressScreen.SetActive(false);
        dialogueManager.Show("ГГ", "Выгляжу отлично. Пора начинать!");
        characterManager.CurrentName = "ГГ";
        characterManager.SetCharacter("base");
        bgScreen.SetActive(false);
        startStoryBtn.gameObject.SetActive(true);

        continueBtn.onClick.RemoveListener(Continue);
    }

    private void Fade()
    {
        fader.FadeIn(StartPlot);
    }

    private void StartPlot()
    {
        continueBtn.onClick.AddListener(storyManager.CloseDress);

        dressScreen.SetActive(false);
        dressBG.SetActive(false);
        storyBG.SetActive(true);
        startStoryBtn.gameObject.SetActive(false);
        storyManager.NextNode();
        nextButton.gameObject.SetActive(true);
        this.enabled = false;
    }
}
