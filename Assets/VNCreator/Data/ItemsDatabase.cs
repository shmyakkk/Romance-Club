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

            Accessories = SortByIndex(Accessories);
            Hair = SortByIndex(Hair);
            Dress = SortByIndex(Dress);
            Appearance = SortByIndex(Appearance);



            AllItems = new Item[4][];

            AllItems[0] = Appearance;
            AllItems[1] = Dress;
            AllItems[2] = Hair;
            AllItems[3] = Accessories;
        }

        private static Item[] SortByIndex(Item[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].Id < array[i].Id)
                    {
                        Item temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }

            return array;
        }
    }
}
