using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VNCreator
{
    public class DressingRoom : MonoBehaviour
    {
        [Header("Categories")]
        [SerializeField] private GameObject appearanceItems;
        [SerializeField] private GameObject dressItems;
        [SerializeField] private GameObject hairItems;
        [SerializeField] private GameObject accessoriesItems;

        [Header("Buttons")]
        [SerializeField] private Button appearanceBtn;
        [SerializeField] private Button dresseBtn;
        [SerializeField] private Button hairBtn;
        [SerializeField] private Button accessoriesBtn;

        [SerializeField] private Sprite selectedSprite;
        [SerializeField] private Sprite unselectedSprite;

        private void Start()
        {
            appearanceBtn.onClick.AddListener(ShowAppearance);
            dresseBtn.onClick.AddListener(ShowDress);
            hairBtn.onClick.AddListener(ShowHair);
            accessoriesBtn.onClick.AddListener(ShowAccessories);
        }

        private void ShowAppearance()
        {
            appearanceBtn.gameObject.GetComponent<Image>().sprite = selectedSprite;
            dresseBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            hairBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            accessoriesBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;

            appearanceItems.SetActive(true);
            dressItems.SetActive(false); 
            hairItems.SetActive(false);
            accessoriesItems.SetActive(false);
        }
        private void ShowDress()
        {
            appearanceBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            dresseBtn.gameObject.GetComponent<Image>().sprite = selectedSprite;
            hairBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            accessoriesBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;

            appearanceItems.SetActive(false);
            dressItems.SetActive(true);
            hairItems.SetActive(false);
            accessoriesItems.SetActive(false);
        }
        private void ShowHair()
        {
            appearanceBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            dresseBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            hairBtn.gameObject.GetComponent<Image>().sprite = selectedSprite;
            accessoriesBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;

            appearanceItems.SetActive(false);
            dressItems.SetActive(false);
            hairItems.SetActive(true);
            accessoriesItems.SetActive(false);
        }
        private void ShowAccessories()
        {
            appearanceBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            dresseBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            hairBtn.gameObject.GetComponent<Image>().sprite = unselectedSprite;
            accessoriesBtn.gameObject.GetComponent<Image>().sprite = selectedSprite;

            appearanceItems.SetActive(false);
            dressItems.SetActive(false);
            hairItems.SetActive(false);
            accessoriesItems.SetActive(true);
        }
    }
}
