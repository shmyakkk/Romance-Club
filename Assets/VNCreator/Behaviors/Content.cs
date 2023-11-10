using UnityEngine;
using UnityEngine.UI;

namespace VNCreator
{
    public class Content : MonoBehaviour
    {
        [SerializeField] private GameObject itemPrefab;

        [SerializeField] private Image appearanceImg;
        [SerializeField] private Image dressImg;
        [SerializeField] private Image hairImg;
        [SerializeField] private Image accessoriesImg;


        private void Start()
        {
            UpdateCharacterView();
            Show(ItemsDatabase.Category.Appearance);
        }

        public void UpdateCharacterView()
        {
            if (appearanceImg)
            appearanceImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Appearance).sprite;

            if (dressImg)
            dressImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Dress).sprite;

            if (hairImg)
            hairImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Hair).sprite;

            if (accessoriesImg)
            accessoriesImg.sprite = ItemsDatabase.FindCurrentItem(ItemsDatabase.Category.Accessories).sprite;
        }

        public void Show(ItemsDatabase.Category category)
        {
            DeleteItems();

            float xPos = 0;

            Item[] items = ItemsDatabase.AllItems[(int)category];

            foreach (Item item in items)
            {
                if (item.isEnabled == false) continue;

                Vector2 position = new(xPos, 0);
                var tileObject = Instantiate(itemPrefab, gameObject.transform);
                var tile = tileObject.GetComponent<ContentItemUI>();

                tile.CreateItem(item, GetComponent<ToggleGroup>(), new Vector2(xPos, 0));

                if (item.Id == PlayerPrefs.GetInt(category.ToString()))
                    tile.ChangeUI(true);
                else tile.ChangeUI(false);

                xPos += 220;
            }

            Invoke(nameof(StretchScrollViewContent), 0.1f);
        }

        private void DeleteItems()
        {
            int childCount = transform.childCount;

            for (int i = childCount - 1; i >= 0; i--)
            {
                Transform child = transform.GetChild(i);

                Destroy(child.gameObject);
            }
        }

        private void StretchScrollViewContent()
        {
            Vector2 contentSize = CalculateContentSize();
            var rect = GetComponent<RectTransform>();

            rect.sizeDelta = contentSize;
            rect.anchoredPosition = Vector2.zero;
        }

        private Vector2 CalculateContentSize()
        {
            Vector2 size = Vector2.zero;

            for (int i = 0; i < GetComponent<RectTransform>().childCount; i++)
            {
                RectTransform child = GetComponent<RectTransform>().GetChild(i) as RectTransform;
                if (child != null)
                {
                    Vector2 childSize = child.sizeDelta + child.anchoredPosition;
                    size.x = Mathf.Max(size.x, childSize.x);
                    size.y = Mathf.Max(size.y, childSize.y);
                }
            }

            return size;
        }
    }
}
