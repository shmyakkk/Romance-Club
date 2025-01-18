using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text nameTag;
    [SerializeField] private TMP_Text message;
    [SerializeField] private TMP_Text hiddenMessage;
    [SerializeField] private GameObject currentDiamondsPanel;
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private GameObject dialogueBG;
    [SerializeField] private GameObject choices;

    private Coroutine printingCoroutine;
    private bool isPrinting = false;
    private string currentText;

    private float startedY = 0;
    private float startedHeight = 300;

    public bool IsPrinting { get => isPrinting; private set => isPrinting = value; }

    private string currentSentence = "";
    private string currentName = "";

    public void UpdateCurrentSentence()
    {
        SetText(currentSentence);
        SetName(currentName);
    }

    public void SetText(string currentSentence)
    {
        this.currentSentence = currentSentence;

        Vector2 currentPos = dialogueBG.GetComponent<RectTransform>().localPosition;
        Vector2 currentSize = dialogueBG.GetComponent<RectTransform>().sizeDelta;

        dialogueBG.GetComponent<RectTransform>().localPosition = new Vector2(currentPos.x, startedY);
        dialogueBG.GetComponent<RectTransform>().sizeDelta = new Vector2(currentSize.x, startedHeight);


        currentPos = dialogueBG.GetComponent<RectTransform>().localPosition;
        currentSize = dialogueBG.GetComponent<RectTransform>().sizeDelta;

        int offsetPosY = 0;
        int offsetHeight = 0;

        Vector2 currentPoschoices = choices.GetComponent<RectTransform>().localPosition;

        Debug.Log(choices.GetComponent<RectTransform>().localPosition);

        switch (CountLines(currentSentence))
        {
            case 4:
                offsetPosY = 50;
                offsetHeight = 60;
                choices.GetComponent<RectTransform>().anchoredPosition = new Vector2(currentPoschoices.x, -1210);
                break;
            case 5:
                offsetPosY = 105;
                offsetHeight = 130;

                break;
            case 6:
                offsetPosY = 160;
                offsetHeight = 200;
                break;
            case 7:
                offsetPosY = 205;
                offsetHeight = 260;
                break;
            default:
                choices.GetComponent<RectTransform>().anchoredPosition = new Vector2(currentPoschoices.x, -1156);
                break;
        }

        dialogueBG.GetComponent<RectTransform>().localPosition = new Vector2(currentPos.x, currentPos.y - offsetPosY);
        dialogueBG.GetComponent<RectTransform>().sizeDelta = new Vector2(currentSize.x, currentSize.y + offsetHeight);

        StopAllCoroutines();
        printingCoroutine = StartCoroutine(TypeSentence(currentSentence));
    }

    public void SetName(string _name)
    {
        currentName = _name;

        nameTag.fontSize = 40;
        Animator dialogueAnim = gameObject.GetComponent<Animator>();

        switch (_name)
        {
            case "ГГ":
                if (PlayerPrefs.HasKey("PlayerName"))
                    nameTag.text = PlayerPrefs.GetString("PlayerName");
                dialogueAnim.Play("left");
                break;
            case "..":
                characterManager.ClearCharacter();
                nameTag.text = "...";
                dialogueAnim.Play("middle");
                break;
            default:
                nameTag.text = _name;
                dialogueAnim.Play("right");
                break;
        }
        AutoScaleText.FitTextInContainer(nameTag, nameTag.GetComponent<RectTransform>());
    }
    
    public void SetDiamonds(bool isActive)
    {
        currentDiamondsPanel.SetActive(isActive);

        if (isActive)
            currentDiamondsPanel.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("Diamonds").ToString();
    }

    // Type out the sentence letter by letter and make character idle if they were talking
    private IEnumerator TypeSentence(string sentence)
    {
        message.text = string.Empty;
        currentText = sentence;

        if (GameOptions.isInstantText)
        {
            message.text = sentence;
        }
        else
        {
            IsPrinting = true;

            char[] _chars = sentence.ToCharArray();
            string fullString = string.Empty;
            for (int i = 0; i < _chars.Length; i++)
            {
                fullString += _chars[i];
                message.text = fullString;
                yield return new WaitForFixedUpdate();
            }
        }

        IsPrinting = false;
    }

    public void StopTyping()
    {
        if (printingCoroutine != null)
        {
            StopCoroutine(printingCoroutine);
        }
        message.text = currentText;
        isPrinting = false;
    }

    public void SetDialogueActive(bool isActive)
    {
        if (!isActive) StopTyping();
        gameObject.SetActive(isActive);
    }

    public void Show(string name, string sentence)
    {
        gameObject.SetActive(true);
        SetName(name);
        SetText(sentence);
    }

    public int CountLines(string sentence)
    {
        if (hiddenMessage == null)
        {
            Debug.LogError("TMP_Text component is not assigned.");
            return 0;
        }

        hiddenMessage.text = sentence;

        TMP_TextInfo textInfo = hiddenMessage.GetTextInfo(hiddenMessage.text);

        int numberOfLines = textInfo.lineCount;

        Debug.Log(numberOfLines);

        return numberOfLines;
    }
}
