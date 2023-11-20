using UnityEngine;
using UnityEngine.UI;

public class ItemsCategoty : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private Sprite unselectedSprite;

    [Header("Data")]
    [SerializeField] private Content content;
    [SerializeField] private int id;

    private Toggle toggle;

    private void Awake()
    {
        content.UpdateCharacterView();
    }

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ChangeCategory);

        if (id == 0) toggle.isOn = true;
    }

    private void ChangeCategory(bool index)
    {
        if (index)
        {
            GetComponent<Image>().sprite = selectedSprite;
            content.Show((ItemsDatabase.Category)id);

            content.UpdateCharacterView();
        }
        else GetComponent<Image>().sprite = unselectedSprite;
    }
}
