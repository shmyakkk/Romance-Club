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
        public bool isEnabled = false;
        public Sprite sprite;
        public Sprite a_base;
        public Sprite a_dream;
        public Sprite a_evil;
        public Sprite a_flirt;
        public Sprite a_sad;
        public Sprite a_smile;
        public Sprite a_surprise;
        public Sprite a_shadow;
    }
}
