﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] private Image backgroungImg;

    [Header("-")]
    public Button nextBtn;
    public TextAsset inkFile;
    public GameObject customButton;
    public GameObject optionPanel;
    public bool isTalking = false;

    static Story story;
    public Text nameTag;
    public Text message;
    List<string> tags;
    static Choice choiceSelected;

    [SerializeField] private CharacterScript cs;

    // Start is called before the first frame update
    void Start()
    {
        nextBtn.onClick.AddListener(delegate { NextNode(); });
        story = new Story(inkFile.text);
        tags = new List<string>();
        choiceSelected = null;

        NextNode();
    }

    private void NextNode()
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
        ParseTags();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    // Type out the sentence letter by letter and make character idle if they were talking
    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }
        CharacterScript tempSpeaker = GameObject.FindObjectOfType<CharacterScript>();
        if (tempSpeaker.isTalking)
        {
            SetAnimation("idle");
        }
        yield return null;
    }

    // Create then show the choices on the screen until one got selected
    IEnumerator ShowChoices()
    {
        Debug.Log("There are choices need to be made here!");
        List<Choice> _choices = story.currentChoices;

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = Instantiate(customButton, optionPanel.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = _choices[i].text;
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = _choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
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
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "name":
                    SetName(param);
                    break;
                case "anim":
                    SetAnimation(param);
                    break;
                case "bg":
                    SetBG(param);
                    break;
            }
        }
    }

    void SetName(string _name)
    {
        cs.PreviousName = cs.CurrentName;
        cs.CurrentName = _name;

        switch (_name)
        {
            case "ГГ":
                if (PlayerPrefs.HasKey("PlayerName"))
                    nameTag.text = PlayerPrefs.GetString("PlayerName");
                break;
            case "...":
                cs.ClearCharacter();
                nameTag.text = _name;
                break;
            default:
                nameTag.text = _name;
                break;
        }
    }

    void SetAnimation(string _name)
    {
        cs.SetCharacter(_name);
    }

    void SetBG(string _bg)
    {
        backgroungImg.sprite = Resources.Load<Sprite>("BG/" + _bg);
    }
}
