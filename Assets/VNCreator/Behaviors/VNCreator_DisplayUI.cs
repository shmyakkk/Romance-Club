using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_DisplayUI : DisplayBase
    {
        public Fader fader;

        [Header("Start")]
        public GameObject nameSetScreen;
        public GameObject dressScreen;
        public GameObject storyScreen;
        public InputField playerName;
        public Button nameSubmitBtn;
        public Button startStoryBtn;

        [Header("Text")]
        public Text characterNameTxt;
        public Text dialogueTxt;
        [Header("Visuals")]
        public Image appearanceImg;
        public Image dressImg;
        public Image hairImg;
        public Image accessoriesImg;
        public Image backgroundImg;
        public Image dialogueImg;
        [Header("Animation")]
        public Animator characterAnim;
        [Header("Audio")]
        public AudioSource musicSource;
        public AudioSource soundEffectSource;
        [Header("Buttons")]
        public Button nextBtn;
        public Button previousBtn;
        public Button saveBtn;
        public Button menuButton;
        [Header("Choices")]
        public Button choiceBtn1;
        public Button choiceBtn2;
        public Button choiceBtn3;
        public Button choiceBtn4;
        [Header("End")]
        public GameObject endScreen;
        [Header("Main menu")]
        [Scene]
        public string mainMenu;

        private const string IN_LEFT = "In_Left";
        private const string IN_RIGHT = "In_Right";
        private const string OUT_LEFT = "Out_Left";
        private const string OUT_RIGHT = "Out_Right";

        private Action onAnimationEndCallback;

        void Start()
        {
            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Appearance.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Appearance.ToString(), 0);

            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Dress.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Dress.ToString(), 0);

            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Hair.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Hair.ToString(), 0);

            if (!PlayerPrefs.HasKey(ItemsDatabase.Category.Accessories.ToString()))
                PlayerPrefs.SetInt(ItemsDatabase.Category.Accessories.ToString(), 0);

            nameSubmitBtn.onClick.AddListener(SubmitName);
            startStoryBtn.onClick.AddListener(StartStory);

            storyScreen.SetActive(false);
            //endScreen.SetActive(false);
        }

        private void SubmitName()
        {
            if (playerName.text.Length > 0)
            {
                PlayerPrefs.SetString("PlayerName", playerName.text);
            }
            else
            {
                PlayerPrefs.SetString("PlayerName", "Кейт");
            }
        }

        private void StartStory()
        {
            storyScreen.SetActive(true);
            dressScreen.SetActive(false);

            nextBtn.onClick.AddListener(delegate { NextNode(0); });
            if (previousBtn != null)
                previousBtn.onClick.AddListener(Previous);
            if (saveBtn != null)
                saveBtn.onClick.AddListener(Save);
            if (menuButton != null)
                menuButton.onClick.AddListener(ExitGame);

            if (choiceBtn1 != null)
                choiceBtn1.onClick.AddListener(delegate { NextNode(0); });
            if (choiceBtn2 != null)
                choiceBtn2.onClick.AddListener(delegate { NextNode(1); });
            if (choiceBtn3 != null)
                choiceBtn3.onClick.AddListener(delegate { NextNode(2); });
            if (choiceBtn4 != null)
                choiceBtn4.onClick.AddListener(delegate { NextNode(3); });

            ShowCurrentNode();
        }

        protected override void NextNode(int _choiceId)
        {
            if (lastNode)
            {
                SceneManager.LoadScene("Menu");
                return;
            }

            base.NextNode(_choiceId);

            if (currentNode.isFade)
            {
                fader.FadeIn(ShowCurrentNode);
            }
            else
            {
                ShowCurrentNode();
            }
        }

        void ShowCurrentNode()
        {
            SetCharacter();
            SetBG();

            //выборы
            if (currentNode.choices <= 1)
            {
                nextBtn.gameObject.SetActive(true);

                choiceBtn1.gameObject.SetActive(false);
                choiceBtn2.gameObject.SetActive(false);
                choiceBtn3.gameObject.SetActive(false);
                choiceBtn4.gameObject.SetActive(false);

                //previousBtn.gameObject.SetActive(loadList.Count != 1);
            }
            else
            {
                nextBtn.gameObject.SetActive(false);

                choiceBtn1.gameObject.SetActive(true);
                choiceBtn1.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[0];

                choiceBtn2.gameObject.SetActive(true);
                choiceBtn2.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[1];

                if (currentNode.choices == 3)
                {
                    choiceBtn3.gameObject.SetActive(true);
                    choiceBtn3.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[2];

                    if (currentNode.choices == 4)
                    {
                        choiceBtn4.gameObject.SetActive(true);
                        choiceBtn4.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[3];
                    }
                    else
                    {
                        choiceBtn4.gameObject.SetActive(false);
                    }
                }
                else
                {
                    choiceBtn3.gameObject.SetActive(false);
                    choiceBtn4.gameObject.SetActive(false);
                }
            }

            StartCoroutine(ShowDialogueText());
        }

        IEnumerator ShowDialogueText()
        {
            dialogueTxt.text = string.Empty;
            if (GameOptions.isInstantText)
            {
                dialogueTxt.text = currentNode.dialogueText;
            }
            else
            {
                char[] _chars = currentNode.dialogueText.ToCharArray();
                string fullString = string.Empty;
                for (int i = 0; i < _chars.Length; i++)
                {
                    fullString += _chars[i];
                    dialogueTxt.text = fullString;
                    yield return new WaitForSeconds(0.01f/ GameOptions.readSpeed);
                }
            }
        }

        protected override void Previous()
        {
            base.Previous();
            ShowCurrentNode();
        }

        void ExitGame()
        {
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        }


        void SetCharacter()
        {
            //гг
            if (currentNode.characterName == "гг")
            {
                if (previousNode != null)
                {
                    if (previousNode.characterName != "гг")
                    {
                        if (previousNode.characterName != "")
                        {
                            PlayAnimation(OUT_RIGHT, SetPlayerAppearance);
                        }
                        else
                        {
                            SetPlayerAppearance();
                        }
                    }
                }
                else SetPlayerAppearance();
            }
            //без перса
            else if (currentNode.characterName == "")
            {
                if (previousNode != null)
                {
                    if (previousNode.characterName != "")
                    {
                        if (previousNode.characterName == "гг")
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
            //другой перс
            else
            {
                if (previousNode != null)
                {
                    if (previousNode.characterName == "гг")
                    {
                        PlayAnimation(OUT_LEFT, SetAnotherCharacterAppearance);
                    }
                    else if (previousNode.characterName == "")
                    {
                        SetAnotherCharacterAppearance();
                    }
                    else
                    {
                        PlayAnimation(OUT_RIGHT, SetAnotherCharacterAppearance);
                    }
                }
            }
        }
        void SetBG()
        {
            //задний фон
            if (currentNode.backgroundSpr != null)
                backgroundImg.sprite = currentNode.backgroundSpr;

            if (currentNode.dialogueSpr != null)
                dialogueImg.sprite = currentNode.dialogueSpr;

            if (currentNode.backgroundMusic != null)
                VNCreator_MusicSource.instance.Play(currentNode.backgroundMusic);
            if (currentNode.soundEffect != null)
                VNCreator_SfxSource.instance.Play(currentNode.soundEffect);
        }


        void PlayAnimation(string animationName, Action onAnimationEnd)
        {
            onAnimationEndCallback = onAnimationEnd;
            characterAnim.Play(animationName, 0, 0f);
            StartCoroutine(WaitForAnimationEnd(animationName));
        }

        IEnumerator WaitForAnimationEnd(string animationName)
        {
            while (!characterAnim.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            {
                yield return null;
            }

            float animationLength = characterAnim.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);

            if (onAnimationEndCallback != null)
            {
                onAnimationEndCallback.Invoke();
            }
        }

        void SetPlayerAppearance()
        {
            if (PlayerPrefs.HasKey("PlayerName"))
                characterNameTxt.text = PlayerPrefs.GetString("PlayerName");

            if (PlayerPrefs.HasKey(ItemsDatabase.Category.Appearance.ToString()) && appearanceImg)
            {
                appearanceImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Appearance).sprite;
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

        void SetAnotherCharacterAppearance()
        {
            appearanceImg.enabled = true;
            dressImg.enabled = false;
            hairImg.enabled = false;

            characterNameTxt.text = currentNode.characterName;
            appearanceImg.sprite = currentNode.characterSpr;

            PlayAnimation(IN_RIGHT, null);
        }

        void SetNone()
        {
            characterNameTxt.text = "...";

            appearanceImg.enabled = false;
            dressImg.enabled = false;
            hairImg.enabled = false;
        }
    }
}