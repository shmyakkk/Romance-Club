﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public TextAsset inkFile;

    [Header("Visuals")]
    [SerializeField] private Image backgroungImg;

    [Header("Main")]
    public Button nextBtn;
    public GameObject baseChoiceButton;
    public GameObject diamondsChoiceButton;
    public GameObject optionPanel;
    public Button dressBtn;
    public Button menuBtn;
    public GameObject UI;
    public GameObject finishScreen;
    public Button finishBtn;
    public GameObject timer;


    [Header("Info")]
    public GameObject infoPanel;
    public GameObject infoProfessionalism;
    public GameObject infoScandal;

    [Header("Object Panel")]
    [SerializeField] private GameObject objectPanel;
    [SerializeField] private Text objectName;
    [SerializeField] private GameObject acceptChoiceButton;
    [SerializeField] private GameObject objectLeftButton;
    [SerializeField] private GameObject objectRightButton;

    public static Story story;
    
    List<string> tags;
    static Choice choiceSelected;

    [Header("Dress Choices")]
    [SerializeField] private GameObject dressChoices;
    [SerializeField] private Button dressLeftBtn;
    [SerializeField] private Button dressRightBtn;
    public GameObject dressBaseChoiceButton;
    public GameObject dressDiamondsChoiceButton;
    public GameObject dressOptionPanel;

    [Header("Scripts")]
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private DialogueManager dialogueManager;
    public Fader fader;


    [Header("DEV")]
    [SerializeField] private Develop developScript;

    // Start is called before the first frame update
    void Start()
    {
        nextBtn.onClick.AddListener(delegate { NextNode(); });
        finishBtn.onClick.AddListener(GoToMenu);

        dressBtn.onClick.RemoveAllListeners();
        dressBtn.onClick.AddListener(delegate { OpenDress(); });

        menuBtn.onClick.AddListener(GoToMenu);

        story = new Story(inkFile.text);

        if (PlayerPrefs.GetString("Story") == "")
        {
            story.ResetState();
        }
        else
        {
            developScript.gameObject.SetActive(true);

            string savedState = PlayerPrefs.GetString("Story");
            story.state.LoadJson(savedState);

            backgroungImg.sprite = Resources.Load<Sprite>("BG/" + PlayerPrefs.GetString("BG"));
        }

        story.ObserveVariable("professionalism", (string varName, object newValue) => {
        SetProfessionalism((int)newValue);
        });

        story.ObserveVariable("scandal", (string varName, object newValue) => {
            SetScandal((int)newValue);
        });

        story.ObserveVariable("dress", (string varName, object newValue) => {
            PlayerPrefs.SetInt("Dress", (int)newValue);
            characterManager.ChangeDress();
        });

        story.ObserveVariable("chapter_number", (string varName, object newValue) => {
            PlayerPrefs.SetInt("Chapter", (int)newValue);
        });

        if (!PlayerPrefs.HasKey("Diamonds"))
            PlayerPrefs.SetInt("Diamonds", 50);

        if (!PlayerPrefs.HasKey("Professionalism"))
            PlayerPrefs.SetInt("Professionalism", 0);

        if (!PlayerPrefs.HasKey("Scandal"))
            PlayerPrefs.SetInt("Scandal", 0);

        tags = new List<string>();
        choiceSelected = null;

        dialogueManager.SetDiamonds(false);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    private void SetProfessionalism(int newValue)
    {
        Animator anim = infoProfessionalism.GetComponent<Animator>();
        infoProfessionalism.GetComponentInChildren<UnityEngine.UI.Text>().text = "+1" + " Профессионализм";

        PlayerPrefs.SetInt("Professionalism", newValue);

        anim.SetTrigger("show");
    }
    private void SetScandal(int newValue)
    {
        Animator anim = infoScandal.GetComponent<Animator>();
        infoScandal.GetComponentInChildren<UnityEngine.UI.Text>().text = "+1" + " Скандал";

        PlayerPrefs.SetInt("Scandal", newValue);

        anim.SetTrigger("show");
    }

    public void NextNode()
    {
        if (story.canContinue)
        {
            PlayerPrefs.SetString("Story", story.state.ToJson());

            if (dialogueManager.IsPrinting)
            {
                dialogueManager.StopTyping();
            }
            else
            {
                int choiceOption = AdvanceDialogue();

                //Are there any choices?
                if (story.currentChoices.Count != 0)
                {
                    switch (choiceOption)
                    {
                        case 0:
                            break;
                        case 1:
                            StartCoroutine(ShowChoices());
                            break;
                        case 2:
                            StartCoroutine(ShowDressChoices());
                            break;
                        case 3:
                            StartCoroutine(ShowObjectsChoices());
                            break;
                    }
                }
            }
        }
        else
        {
            if (dialogueManager.IsPrinting)
            {
                dialogueManager.StopTyping();
            }
        }
    }

    public void SetPartNumber(string part)
    {
        story.ChoosePathString(part);
    }

    // Finished the Story (Dialogue)
    private void FinishDialogue()
    {
        PlayerPrefs.SetString("Story", story.state.ToJson());

        fader.Fade(() =>
        {
            finishScreen.SetActive(true);
            GetComponent<MusicManager>().StopBGM();
        });
    }

    // Advance through the story 
    int AdvanceDialogue()
    {
        string currentSentence = story.Continue();

        string namePattern = @"^(.*?)(\s\(([^)]+)\))?:\s";
        string emotionPattern = @"\(([^)]+)\)";
        string dressPattern = @"dress";
        string objectPattern = @"object";
        string pausePattern = @"<pause>";

        if (Regex.Match(currentSentence, pausePattern).Success)
        {
            SetName("..");
            characterManager.ClearCharacter();
            dialogueManager.SetDialogueActive(false);

            nextBtn.enabled = false;

            ParseTags();

            return 0;
        }

        Match nameMatch = Regex.Match(currentSentence, namePattern);
        if (nameMatch.Success)
        {
            string name = nameMatch.Groups[1].Value.Trim();
            SetName(name);

            Debug.Log(name);

            string emotion = nameMatch.Groups[3].Value.Trim();
            if (!string.IsNullOrEmpty(emotion))
            {
                SetAnimation(emotion);
            }
        }

        if (currentSentence.Contains("(имя гг)"))
        {
            currentSentence = currentSentence.Replace("(имя гг)", PlayerPrefs.GetString("PlayerName").ToString());
        }

        Match dressMatch = Regex.Match(currentSentence, dressPattern);
        Match objectsMatch = Regex.Match(currentSentence, objectPattern);

        currentSentence = Regex.Replace(currentSentence, namePattern, string.Empty);
        currentSentence = Regex.Replace(currentSentence, emotionPattern, string.Empty);
        currentSentence = Regex.Replace(currentSentence, dressPattern, string.Empty);
        currentSentence = Regex.Replace(currentSentence, objectPattern, string.Empty);

        ParseTags();

        if (dressMatch.Success)
        {
            dressChoices.GetComponentInChildren<Text>().text = currentSentence;
            return 2;
        }
        if (objectsMatch.Success)
        {
            currentSentence = currentSentence.Replace("\n", "");
            acceptChoiceButton.GetComponentInChildren<Text>().text = currentSentence;
            return 3;
        }
        else
        {
            dialogueManager.SetText(currentSentence);
            return 1;
        }
    }



    // Create then show the choices on the screen until one got selected
    IEnumerator ShowChoices()
    {
        List<Choice> _choices = story.currentChoices;

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = null;

            string choiceText = _choices[i].text;

            string text = "";
            int number = 0;

            string diamondsPattern = @"^d(\d+)";
            Match diamondsMatch = Regex.Match(choiceText, diamondsPattern);

            string timerPattern = @"timer";
            Match timerMatch = Regex.Match(choiceText, timerPattern);

            if (diamondsMatch.Success)
            {
                // Получаем число из совпадения и преобразуем его в int
                number = int.Parse(diamondsMatch.Groups[1].Value);

                // Удаляем совпадение из строки
                text = choiceText.Remove(diamondsMatch.Index, diamondsMatch.Length).Trim();

                temp = Instantiate(diamondsChoiceButton, optionPanel.transform);

                dialogueManager.SetDiamonds(true);
            }
            else
            {
                text = choiceText;

                temp = Instantiate(baseChoiceButton, optionPanel.transform);
            }

            Selectable selectable = temp.GetComponent<Selectable>();
            temp.GetComponent<Button>().onClick.AddListener(() => { selectable.Decide(); });

            if (timerMatch.Success)
            {
                text = choiceText.Remove(timerMatch.Index, timerMatch.Length).Trim();

                StartCoroutine(SetTimer(() =>
                {
                    temp.GetComponent<Button>().onClick.Invoke();
                }, 5));
            }

            selectable.SetParameters(text, number);
            selectable.element = _choices[i];
        }

        optionPanel.SetActive(true);

        yield return new WaitUntil(() => { return choiceSelected != null; });

        AdvanceFromDecision();
    }

    // Tells the story which branch to go to
    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        story.ChooseChoiceIndex(choiceSelected.index);

        PlayerPrefs.SetString("Story", story.state.ToJson());
    }

    // After a choice was made, turn off the panel and advance from that choice
    void AdvanceFromDecision()
    {
        ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Dress).isEnabled = true;

        //stop timer
        StopAllCoroutines();
        timer.SetActive(false);

        dialogueManager.SetDialogueActive(true);
        dressChoices.SetActive(false);
        optionPanel.SetActive(false);

        objectLeftButton.SetActive(false);
        objectRightButton.SetActive(false);

        objectPanel.SetActive(false);

        dialogueManager.SetDiamonds(false);

        for (int i = 0; i < optionPanel.transform.childCount; i++)
        {
            Destroy(optionPanel.transform.GetChild(i).gameObject);
        }
        choiceSelected = null; // Forgot to reset the choiceSelected. Otherwise, it would select an option without player intervention.
        AdvanceDialogue();
    }

    void ParseTags()
    {
        tags = story.currentTags;
        foreach (string t in tags)
        {
            string[] words = t.Split(' ');
            string prefix = t.Split(' ')[0];
            string param = string.Join(" ", words, 1, words.Length - 1);

            switch (prefix.ToLower())
            {
                case "started_bg":
                    SetStartedBG(param);
                    break;
                case "bg":
                    SetBG(param);
                    break;
                case "cutscene":
                    SetCutscene(param);
                    break;
                case "info":
                    SetInfo(param);
                    break;
                case "dress":
                    SetDress(int.Parse(param));
                    break;
                case "music":
                    SetMusic(param);
                    break;
                case "end":
                    FinishDialogue();
                    break;
            }
        }
    }

    void SetName(string _name)
    {
        characterManager.PreviousName = characterManager.CurrentName;
        characterManager.CurrentName = _name;

        dialogueManager.SetName(_name);
    }

    void SetAnimation(string _name)
    {
        characterManager.SetCharacter(_name);
    }

    void SetBG(string _bg)
    {
        if (_bg == "blink")
        {
            fader.Blink(() =>
            {
                dialogueManager.SetDialogueActive(true);
                NextNode();

                nextBtn.enabled = true;
            });
        }
        else
        {
            fader.Fade(() =>
            {
                backgroungImg.sprite = Resources.Load<Sprite>("BG/" + _bg);
                PlayerPrefs.SetString("BG", _bg);

                dialogueManager.SetDialogueActive(true);
                NextNode();

                nextBtn.enabled = true;
            });
        }
    }

    void SetStartedBG(string _bg)
    {
        backgroungImg.sprite = Resources.Load<Sprite>("BG/" + _bg);
        PlayerPrefs.SetString("BG", _bg);

        dialogueManager.SetDialogueActive(true);
        NextNode();

        nextBtn.enabled = true;

        fader.FadeOut();
    }

    void SetCutscene(string _bg)
    {
        fader.Fade(() =>
        {
            backgroungImg.sprite = Resources.Load<Sprite>("BG/" + _bg);
            PlayerPrefs.SetString("BG", _bg);

            backgroungImg.GetComponent<Animator>().Play("Kiss", 0, 0f);

            StartCoroutine(WaitForAnimationEnd(backgroungImg.GetComponent<Animator>(), "Kiss", () => nextBtn.enabled = true));
        });
    }

    IEnumerator WaitForAnimationEnd(Animator animator, string animationName, Action onAnimationEndCallback)
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null;
        }

        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        onAnimationEndCallback?.Invoke();
    }

    void SetInfo(string _text)
    {
        Animator anim = infoPanel.GetComponent<Animator>();
        infoPanel.GetComponentInChildren<UnityEngine.UI.Text>().text = _text;

        anim.SetTrigger("show");
    }

    void SetDress(int id)
    {
        PlayerPrefs.SetInt("Dress", id);
    }

    void SetMusic(string _music)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + _music);

        gameObject.GetComponent<MusicManager>().ChangeBGM(audioClip);
    }

    private int currentDress = 0;
    private List<Choice> dressChoicesList = null;
    IEnumerator ShowDressChoices()
    {
        dressChoices.SetActive(true);
        dialogueManager.SetDialogueActive(false);

        dressChoicesList = story.currentChoices;
        currentDress = 0;

        dressLeftBtn.onClick.AddListener(PreviousDress);
        dressRightBtn.onClick.AddListener(NextDress);

        SetChoice(dressChoicesList, currentDress);

        yield return new WaitUntil(() => { return choiceSelected != null; });

        AdvanceFromDecision();
    }

    void NextDress()
    {
        if (dressOptionPanel.GetComponentInChildren<Selectable>().gameObject)
            Destroy(dressOptionPanel.GetComponentInChildren<Selectable>().gameObject);

        if (currentDress == dressChoicesList.Count - 1)
        {
            SetChoice(dressChoicesList, 0);
            currentDress = 0;
        }
        else
        {
            SetChoice(dressChoicesList, currentDress + 1);
            currentDress += 1;
        }

        characterManager.ChangeDress();
    }

    void PreviousDress()
    {
        if (dressOptionPanel.GetComponentInChildren<Selectable>().gameObject)
            Destroy(dressOptionPanel.GetComponentInChildren<Selectable>().gameObject);

        if (currentDress == 0)
        {
            SetChoice(dressChoicesList, dressChoicesList.Count - 1);
            currentDress = dressChoicesList.Count - 1;
        }
        else
        {
            SetChoice(dressChoicesList, currentDress - 1);
            currentDress -= 1;
        }
        characterManager.ChangeDress();

    }

    void SetChoice(List<Choice> choices, int i)
    {
        GameObject temp = null;

        string choiceText = choices[i].text;

        string text = "";
        int number = 0;

        string diamondsPattern = @"^d(\d+)";

        Match diamondsMatch = Regex.Match(choiceText, diamondsPattern);


        string dressPattern = @"dress\d+";
        Regex regex = new Regex(dressPattern);

        MatchCollection matches = regex.Matches(choiceText);
        foreach (Match match in matches)
        {
            string matchValue = match.Value;
            int id = int.Parse(matchValue.Substring(5)); // Преобразование числа в int

            choiceText = choiceText.Replace(matchValue, ""); // Удаление подстроки из строки
            choiceText = choiceText.Trim(); // Удаление лишних пробелов

            PlayerPrefs.SetInt("Dress", id);
        }

        if (diamondsMatch.Success)
        {
            // Получаем число из совпадения и преобразуем его в int
            number = int.Parse(diamondsMatch.Groups[1].Value);

            // Удаляем совпадение из строки
            text = choiceText.Remove(diamondsMatch.Index, diamondsMatch.Length).Trim();

            temp = Instantiate(dressDiamondsChoiceButton, dressOptionPanel.transform);

            //dialogueManager.SetDiamonds(true);
        }
        else
        {
            text = choiceText;

            temp = Instantiate(dressBaseChoiceButton, dressOptionPanel.transform);
        }

        Selectable selectable = temp.GetComponent<Selectable>();
        selectable.SetParameters(text, number);
        selectable.element = choices[i];
        temp.GetComponent<Button>().onClick.AddListener(() => { selectable.Decide(); });
    }


    private int currentObject = 0;
    private List<Choice> objectChoicesList = null;
    IEnumerator ShowObjectsChoices()
    {
        SetName("..");
        characterManager.ClearCharacter();

        objectPanel.SetActive(true);
        dialogueManager.SetDialogueActive(false);

        objectChoicesList = story.currentChoices;
        currentObject = 0;

        if (objectChoicesList.Count > 1)
        {
            objectLeftButton.SetActive(true);
            objectRightButton.SetActive(true);

            objectLeftButton.GetComponent<Button>().onClick.AddListener(PreviousObject);
            objectRightButton.GetComponent<Button>().onClick.AddListener(NextObject);
        }
        
        SetObjectChoice(objectChoicesList, currentObject);

        yield return new WaitUntil(() => { return choiceSelected != null; });

        AdvanceFromDecision();
    }

    void PreviousObject()
    {
        if (currentObject == 0)
        {
            currentObject = objectChoicesList.Count - 1;
        }
        else
        {
            currentObject -= 1;
        }
        SetObjectChoice(objectChoicesList, currentObject);
    }

    void NextObject()
    {
        if (currentObject == objectChoicesList.Count - 1)
        {
            currentObject = 0;
        }
        else
        {
            currentObject += 1;
        }
        SetObjectChoice(objectChoicesList, currentObject);
    }

    void SetObjectChoice(List<Choice> choices, int i)
    {
        objectPanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("Object/" + choices[i].text);

        Selectable selectable = acceptChoiceButton.GetComponent<Selectable>();
        selectable.SetParameters(choices[i].text, 0);
        selectable.element = choices[i];
        acceptChoiceButton.GetComponent<Button>().onClick.AddListener(() => { selectable.Decide(); });
    }

    public void OpenDress()
    {
        UI.SetActive(false);
    }

    public void CloseDress()
    {
        UI.SetActive(true);

        dialogueManager.UpdateCurrentSentence();

        if (characterManager.CurrentName == "ГГ")
            characterManager.UpdateCharacterApperance(characterManager.CurrentEmotion);
    }

    private IEnumerator SetTimer(Action action, int time)
    {
        timer.SetActive(true);
        var timerText = timer.GetComponentInChildren<Text>();

        while (time > 0)
        {
            timerText.text = time.ToString();
            time -= 1;

            yield return new WaitForSeconds(1);
        }

        timer.SetActive(false);

        action?.Invoke();
    }
}
