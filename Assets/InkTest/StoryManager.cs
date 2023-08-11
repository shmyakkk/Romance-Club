using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using VNCreator;

public class StoryManager : MonoBehaviour
{
    public TextAsset inkFile;

    [Header("Visuals")]
    [SerializeField] private Image backgroungImg;

    [Header("Objects")]
    public Button nextBtn;
    public GameObject baseChoiceButton;
    public GameObject diamondsChoiceButton;
    public GameObject optionPanel;

    [Header("Info")]
    public GameObject infoPanel;
    public GameObject infoProfessionalism;
    public GameObject infoScandal;

    static Story story;
    
    List<string> tags;
    static Choice choiceSelected;

    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        nextBtn.onClick.AddListener(delegate { NextNode(); });
        story = new Story(inkFile.text);

        story.ObserveVariable("professionalism", (string varName, object newValue) => {
        SetProfessionalism((int)newValue);
        });

        story.ObserveVariable("scandal", (string varName, object newValue) => {
            SetScandal((int)newValue);
        });

        if (!PlayerPrefs.HasKey("Diamonds"))
            PlayerPrefs.SetInt("Diamonds", 0);

        tags = new List<string>();
        choiceSelected = null;

        dialogueManager.SetDiamonds(false);
    }

    private void SetProfessionalism(int newValue)
    {
        Animator anim = infoProfessionalism.GetComponent<Animator>();
        infoProfessionalism.GetComponentInChildren<UnityEngine.UI.Text>().text = "+" + newValue.ToString() + " Профессионализм";

        anim.SetTrigger("show");
    }
    private void SetScandal(int newValue)
    {
        Animator anim = infoScandal.GetComponent<Animator>();
        infoScandal.GetComponentInChildren<UnityEngine.UI.Text>().text = "+" + newValue.ToString() + " Скандал";

        anim.SetTrigger("show");
    }

    public void NextNode()
    {
        //Is there more to the story?
        if (story.canContinue)
        {
            AdvanceDialogue();

            //Are there any choices?
            if (story.currentChoices.Count != 0)
            {
                StartCoroutine(ShowChoices());
            }
        }
        else
        {
            FinishDialogue();
        }
    }

    // Finished the Story (Dialogue)
    private void FinishDialogue()
    {
        Debug.Log("End of Dialogue!");
    }

    // Advance through the story 
    void AdvanceDialogue()
    {
        string currentSentence = story.Continue();

        string namePattern = @"^(.*?)(\s\([^\)]+\))?:\s";
        string emotionPattern = @"\(([^)]+)\)";

        Match nameMatch = Regex.Match(currentSentence, namePattern);
        if (nameMatch.Success)
        {
            string name = nameMatch.Groups[1].Value.Trim();
            SetName(name);

            Match emotionMatch = Regex.Match(nameMatch.Groups[2].Value, emotionPattern);
            if (emotionMatch.Success)
            {
                string emotion = emotionMatch.Groups[1].Value.Trim();
                SetAnimation(emotion);
            }
        }

        currentSentence = Regex.Replace(currentSentence, namePattern, string.Empty);
        currentSentence = Regex.Replace(currentSentence, emotionPattern, string.Empty);

        ParseTags();
        
        dialogueManager.SetText(currentSentence);
    }



    // Create then show the choices on the screen until one got selected
    IEnumerator ShowChoices()
    {
        Debug.Log("There are choices need to be made here!");
        List<Choice> _choices = story.currentChoices;

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = null;

            string choiceText = _choices[i].text;

            string text = "";
            int number = 0;

            string pattern = @"^d(\d+)";
            Match match = Regex.Match(choiceText, pattern);

            if (match.Success)
            {
                // Получаем число из совпадения и преобразуем его в int
                number = int.Parse(match.Groups[1].Value);

                // Удаляем совпадение из строки
                text = choiceText.Remove(match.Index, match.Length).Trim();

                temp = Instantiate(diamondsChoiceButton, optionPanel.transform);

                dialogueManager.SetDiamonds(true);
            }
            else
            {
                text = choiceText;

                temp = Instantiate(baseChoiceButton, optionPanel.transform);
            }

            Selectable selectable = temp.GetComponent<Selectable>();
            selectable.SetParameters(text, number);
            selectable.element = _choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { selectable.Decide(); });
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
    }

    // After a choice was made, turn off the panel and advance from that choice
    void AdvanceFromDecision()
    {
        optionPanel.SetActive(false);

        dialogueManager.SetDiamonds(false);

        for (int i = 0; i < optionPanel.transform.childCount; i++)
        {
            Destroy(optionPanel.transform.GetChild(i).gameObject);
        }
        choiceSelected = null; // Forgot to reset the choiceSelected. Otherwise, it would select an option without player intervention.
        AdvanceDialogue();
    }

    /*** Tag Parser ***/
    /// In Inky, you can use tags which can be used to cue stuff in a game.
    /// This is just one way of doing it. Not the only method on how to trigger events. 
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
                case "bg":
                    SetBG(param);
                    break;
                case "info":
                    SetInfo(param);
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
        backgroungImg.sprite = Resources.Load<Sprite>("BG/" + _bg);
    }

    void SetInfo(string _text)
    {
        Animator anim = infoPanel.GetComponent<Animator>();
        infoPanel.GetComponentInChildren<UnityEngine.UI.Text>().text = _text;

        anim.SetTrigger("show");
    }
}
