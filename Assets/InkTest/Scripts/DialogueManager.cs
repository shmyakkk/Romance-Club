using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using VNCreator;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text nameTag;
    [SerializeField] private Text message;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject currentDiamondsPanel;
    [SerializeField] private CharacterManager characterManager;

    private Coroutine printingCoroutine;
    private bool isPrinting = false;
    private string currentText;

    public bool IsPrinting { get => isPrinting; private set => isPrinting = value; }

    public void SetText(string currentSentence)
    {
        StopAllCoroutines();
        printingCoroutine = StartCoroutine(TypeSentence(currentSentence));
    }

    public void SetName(string _name)
    {
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

    public void SetDialogueActive(bool isActive) => gameObject.SetActive(isActive);

    public void Show(string name, string sentence)
    {
        gameObject.SetActive(true);
        SetName(name);
        SetText(sentence);
    }
}
