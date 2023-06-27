using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VNCreator
{
    [CreateAssetMenu(fileName = "New Item", menuName = "New Item")]
    public class Item : ScriptableObject
    {
        public string category;
        public int Id = 0;
        public Sprite sprite;
    }
}
