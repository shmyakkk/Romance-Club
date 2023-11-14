using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class Develop : MonoBehaviour
{
    [SerializeField] private StoryManager storyManager;
    [SerializeField] private TMP_InputField inputPart;

    private void Start()
    {
        inputPart.onEndEdit.AddListener(GoToPart);
    }

    public void GoToPart(string partNumber)
    {
        storyManager.SetPartNumber("part_" + partNumber);
    }
}
