using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Image appearanceImg;
    [SerializeField] private Image dressImg;
    [SerializeField] private Image hairImg;
    [SerializeField] private Image accessoriesImg;

    public Animator anim;
    public bool isTalking;

    private Action onAnimationEndCallback;

    private const string IN_LEFT = "In_Left";
    private const string IN_RIGHT = "In_Right";
    private const string OUT_LEFT = "Out_Left";
    private const string OUT_RIGHT = "Out_Right";

    private string previousName;
    private string currentName;
    private string currentEmotion;

    public string PreviousName { get => previousName; set => previousName = value; }
    public string CurrentName { get => currentName; set => currentName = value; }
    public string CurrentEmotion { get => currentEmotion; set => currentEmotion = value; }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isTalking = false;
    }

    public void ChangeDress()
    {
        dressImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Dress).sprite;
        dressImg.enabled = true;
    }

    public void SetCharacter(string anim)
    {
        switch (currentName)
        {
            case "ГГ":
                if (previousName != null)
                {
                    if (previousName != "ГГ")
                    {
                        if (previousName != "...")
                        {
                            PlayAnimation(OUT_RIGHT, delegate { SetPlayerAppearance(anim); });
                        }
                        else
                        {
                            SetPlayerAppearance(anim);
                        }
                    }
                }
                else SetPlayerAppearance(anim);
                break;
            case "...":
                break;
            default:
                if (previousName != null)
                {
                    if (previousName == "ГГ")
                    {
                        PlayAnimation(OUT_LEFT, delegate { SetAnotherCharacterAppearance(anim); });
                    }
                    else if (previousName == "...")
                    {
                        SetAnotherCharacterAppearance(anim);
                    }
                    else if (currentName != previousName)
                    {
                        PlayAnimation(OUT_RIGHT, delegate { SetAnotherCharacterAppearance(anim); });
                    }
                }
                break;
        }
    }

    void PlayAnimation(string animationName, Action onAnimationEnd)
    {
        onAnimationEndCallback = onAnimationEnd;
        anim.Play(animationName, 0, 0f);
        StartCoroutine(WaitForAnimationEnd(animationName));
    }

    IEnumerator WaitForAnimationEnd(string animationName)
    {
        while (!anim.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null;
        }

        float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        onAnimationEndCallback?.Invoke();
    }

    private void SetPlayerAppearance(string a)
    {
        currentEmotion = a;

        if (a == "none")
        {
            SetNone();
            return;
        }

        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Appearance.ToString()) && appearanceImg)
        {
            var item = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Appearance);

            appearanceImg.sprite = a switch
            {
                "base" => item.a_base,
                "displeasure" => item.a_displeasure,
                "dream" => item.a_dream,
                "dream_2" => item.a_dream_2,
                "evil" => item.a_evil,
                "flirt" => item.a_flirt,
                "flirt_2" => item.a_flirt_2,
                "laugh" => item.a_laugh,
                "sad" => item.a_sad,
                "smile" => item.a_smile,
                "surprise" => item.a_surprise,
                "wide_smile" => item.a_wide_smile,
                "shadow" => item.a_shadow,
                _ => item.sprite,
            };
            appearanceImg.enabled = true;
        }

        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Dress.ToString()) && dressImg)
        {
            dressImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Dress).sprite;
            dressImg.enabled = true;
        }

        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Hair.ToString()) && hairImg)
        {
            hairImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Hair).sprite;
            hairImg.enabled = true;
        }

        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Accessories.ToString()) && accessoriesImg)
            accessoriesImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Accessories).sprite;

        PlayAnimation(IN_LEFT, null);
    }

    public void UpdateCharacterApperance(string a)
    {
        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Appearance.ToString()) && appearanceImg)
        {
            if (a == "none")
            {
                SetNone();
                return;
            }

            var item = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Appearance);

            appearanceImg.sprite = a switch
            {
                "base" => item.a_base,
                "displeasure" => item.a_displeasure,
                "dream" => item.a_dream,
                "dream_2" => item.a_dream_2,
                "evil" => item.a_evil,
                "flirt" => item.a_flirt,
                "flirt_2" => item.a_flirt_2,
                "laugh" => item.a_laugh,
                "sad" => item.a_sad,
                "smile" => item.a_smile,
                "surprise" => item.a_surprise,
                "wide_smile" => item.a_wide_smile,
                "shadow" => item.a_shadow,
                _ => item.sprite,
            };
            appearanceImg.enabled = true;
        }
        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Dress.ToString()) && dressImg)
        {
            dressImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Dress).sprite;
            dressImg.enabled = true;
        }

        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Hair.ToString()) && hairImg)
        {
            hairImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Hair).sprite;
            hairImg.enabled = true;
        }

        if (PlayerPrefs.HasKey(ItemsDatabase.Category.Accessories.ToString()) && accessoriesImg)
            accessoriesImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Accessories).sprite;
    }

    void SetAnotherCharacterAppearance(string a)
    {
        if (a == "none") 
        { 
            SetNone();
            return;
        }

        var item = Resources.Load<Item>("Items/Other/" + currentName);

        appearanceImg.sprite = a switch
        {
            "base" => item.a_base,
            "displeasure" => item.a_displeasure,
            "dream" => item.a_dream,
            "dream_2" => item.a_dream_2,
            "evil" => item.a_evil,
            "flirt" => item.a_flirt,
            "flirt_2" => item.a_flirt_2,
            "laugh" => item.a_laugh,
            "sad" => item.a_sad,
            "smile" => item.a_smile,
            "surprise" => item.a_surprise,
            "wide_smile" => item.a_wide_smile,
            "shadow" => item.a_shadow,
            _ => item.sprite,
        };

        appearanceImg.enabled = true;
        dressImg.enabled = false;
        hairImg.enabled = false;

        PlayAnimation(IN_RIGHT, null);
    }

    void SetNone()
    {
        appearanceImg.enabled = false;
        dressImg.enabled = false;
        hairImg.enabled = false;
    }

    public void ClearCharacter()
    {
        if (previousName != null)
        {
            if (previousName != "...")
            {
                if (previousName == "ГГ")
                {
                    PlayAnimation(OUT_LEFT, SetNone);
                }
                else
                {
                    PlayAnimation(OUT_RIGHT, SetNone);
                }
            }
        }
        else
        {
            SetNone();
        }
    }
}
