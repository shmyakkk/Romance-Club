using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text nameTag;
    [SerializeField] private Text message;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject currentDiamondsPanel;
    [SerializeField] private CharacterManager characterManager;

    public void SetText(string currentSentence) => StartCoroutine(TypeSentence(currentSentence));

    public void SetName(string _name)
    {
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
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }
        CharacterManager tempSpeaker = GameObject.FindObjectOfType<CharacterManager>();
        yield return null;
    }
}
