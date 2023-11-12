using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBehavior : MonoBehaviour
{
    [SerializeField] private Sprite toggleOn;
    [SerializeField] private Sprite toggleOff;

    public void ChangeSprite()
    {
        if (GetComponent<Toggle>().isOn)
            gameObject.GetComponent<Image>().sprite = toggleOn;
        else gameObject.GetComponent<Image>().sprite = toggleOff;
    }
}
