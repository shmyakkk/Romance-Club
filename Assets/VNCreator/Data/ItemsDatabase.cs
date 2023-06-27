using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VNCreator
{
    public static class ItemsDatabase
    {
        public static Item[] Accessories { get; private set; }
        public static Item[] Hair { get; private set; }
        public static Item[] Dress { get; private set; }
        public static Item[] Appearance { get; private set; }

        public static Item[][] AllItems { get; private set; }

        public enum Category
        {
            Appearance = 0,
            Dress = 1,
            Hair = 2,
            Accessories = 3
        }

        public static Item FindCurrentItem(Category category)
        {
            foreach (var item in AllItems[(int)category])
            {
                if (item.Id == PlayerPrefs.GetInt(category.ToString()))
                    return item;
            }
            return null;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Accessories = Resources.LoadAll<Item>(path: "Items/Accessories/");
            Hair = Resources.LoadAll<Item>(path: "Items/Hair/");
            Dress = Resources.LoadAll<Item>(path: "Items/Dress/");
            Appearance = Resources.LoadAll<Item>(path: "Items/Appearance/");

            AllItems = new Item[4][];

            AllItems[0] = Appearance;
            AllItems[1] = Dress;
            AllItems[2] = Hair;
            AllItems[3] = Accessories;
        }
    }
}
