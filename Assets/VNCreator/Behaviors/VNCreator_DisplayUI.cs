﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_DisplayUI : DisplayBase
    {
        [Header("Start")]
        public GameObject nameSetScreen;
        public GameObject dressScreen;
        public GameObject storyScreen;
        public InputField playerName;
        public Button nameSubmitBtn;
        
        [Header("Text")]
        public Text characterNameTxt;
        public Text dialogueTxt;
        [Header("Visuals")]
        public Image characterImg;
        public Image backgroundImg;
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

        void Start()
        {
            nameSubmitBtn.onClick.AddListener(SubmitName);

            nextBtn.onClick.AddListener(delegate { NextNode(0); });
            if(previousBtn != null)
                previousBtn.onClick.AddListener(Previous);
            if(saveBtn != null)
                saveBtn.onClick.AddListener(Save);
            if (menuButton != null)
                menuButton.onClick.AddListener(ExitGame);

            if(choiceBtn1 != null)
                choiceBtn1.onClick.AddListener(delegate { NextNode(0); });
            if(choiceBtn2 != null)
                choiceBtn2.onClick.AddListener(delegate { NextNode(1); });
            if(choiceBtn3 != null)
                choiceBtn3.onClick.AddListener(delegate { NextNode(2); });
            if (choiceBtn4 != null)
                choiceBtn4.onClick.AddListener(delegate { NextNode(3); });

            storyScreen.SetActive(false);
            endScreen.SetActive(false);
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

            nameSetScreen.SetActive(false);
            storyScreen.SetActive(true);
            StartStory();
        }

        //edit
        private void StartStory()
        {
            StartCoroutine(DisplayCurrentNode());
        }

        protected override void NextNode(int _choiceId)
        {
            if (lastNode)
            {
                endScreen.SetActive(true);
                return;
            }

            base.NextNode(_choiceId);
            StartCoroutine(DisplayCurrentNode());
        }

        IEnumerator DisplayCurrentNode()
        {
            if (currentNode.characterName == "гг")
            {
                if (PlayerPrefs.HasKey("PlayerName")) 
                    characterNameTxt.text = PlayerPrefs.GetString("PlayerName");
            }
            else
            {
                characterNameTxt.text = currentNode.characterName;
            }

            if (currentNode.characterSpr != null)
            {
                characterImg.sprite = currentNode.characterSpr;
                characterImg.color = Color.white;
            }
            else
            {
                characterImg.color = new Color(1, 1, 1, 0);
            }
            if(currentNode.backgroundSpr != null)
                backgroundImg.sprite = currentNode.backgroundSpr;

            if (currentNode.choices <= 1) 
            {
                nextBtn.gameObject.SetActive(true);

                choiceBtn1.gameObject.SetActive(false);
                choiceBtn2.gameObject.SetActive(false);
                choiceBtn3.gameObject.SetActive(false);
                choiceBtn4.gameObject.SetActive(false);

                previousBtn.gameObject.SetActive(loadList.Count != 1);
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

                    if(currentNode.choices == 4)
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

            if (currentNode.backgroundMusic != null)
                VNCreator_MusicSource.instance.Play(currentNode.backgroundMusic);
            if (currentNode.soundEffect != null)
                VNCreator_SfxSource.instance.Play(currentNode.soundEffect);

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
            StartCoroutine(DisplayCurrentNode());
        }

        void ExitGame()
        {
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        }
    }
}