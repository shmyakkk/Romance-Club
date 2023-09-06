using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{
    [SerializeField] private Text choiceText;
    [SerializeField] private Text diamondsText;

    public object element;
    private bool isActive = false;
    private int neededDiamonds = 0;

    public void SetParameters(string choiceText, int diamondsNumber)
    {
        this.choiceText.text = choiceText;
        if (diamondsText != null)
        {
            diamondsText.text = diamondsNumber.ToString();
            neededDiamonds = diamondsNumber;
        }

        if (PlayerPrefs.GetInt("Diamonds") >= diamondsNumber) isActive = true;
    }

    public void Decide()
    {
        if (isActive)
        {
            if (neededDiamonds > 0)
            {
                int currentDiamonds = PlayerPrefs.GetInt("Diamonds");
                PlayerPrefs.SetInt("Diamonds", currentDiamonds - neededDiamonds);
            }
               
            StoryManager.SetDecision(element);
        }
    }
}
