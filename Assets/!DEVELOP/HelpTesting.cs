using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpTesting : MonoBehaviour
{
    [SerializeField] private StoryManager storyManager;

    [Header("Buttons")]
    [SerializeField] private Button nextPartBtn;
    [SerializeField] private Button previousPartBtn;

    private void Start()
    {
        nextPartBtn.onClick.AddListener(Next);
        previousPartBtn.onClick.AddListener(Previous);
    }

    private void Next()
    {
        storyManager.SetPart("part_2_1");
        storyManager.NextNode();
    }

    private void Previous()
    {

        storyManager.NextNode();
    }
}
