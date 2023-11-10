using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VNCreator
{
    public class StoreMenu : MonoBehaviour
    {
        public Button backButton;

        [Header("Menu Objects")]
        public GameObject storeMenu;
        public GameObject mainMenu;

        private void Start()
        {
            backButton.onClick.AddListener(Back);
        }

        public void Back()
        {
            mainMenu.SetActive(true);
            storeMenu.SetActive(false);
        }
    }
}
