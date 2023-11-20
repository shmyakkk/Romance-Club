using UnityEngine;
using UnityEngine.UI;

public class ContentItemUI : MonoBehaviour
{
    private Item _item;

    public Item Item
    {
        get => _item;

        set
        {
            _item = value;

            icon.sprite = _item.sprite;
        }
    }

    public Image icon;
    public Toggle toggle;

    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private Sprite unselectedSprite;

    private Content content;

    private void Start()
    {
        toggle.onValueChanged.AddListener(SelectItem);
        content = GetComponentInParent<Content>();
    }

    public void SelectItem(bool index)
    {
        PlayerPrefs.SetInt(Item.category, Item.Id);
        ChangeUI(index);
        content.UpdateCharacterView();

        PlayerPrefs.Save();
    }

    public void CreateItem(Item item, ToggleGroup toggleGroup, Vector2 position)
    {
        Item = item;
        toggle.group = toggleGroup;
        GetComponent<RectTransform>().anchoredPosition = position;
    }

    public void ChangeUI(bool isOn)
    {
        if (isOn)
        {
            GetComponent<Image>().sprite = selectedSprite;
        }
        else GetComponent<Image>().sprite = unselectedSprite;

        toggle.isOn = isOn;
    }
}