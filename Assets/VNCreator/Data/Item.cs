using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VNCreator
{
    [CreateAssetMenu(fileName = "New Item", menuName = "New Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private int Id = 0;
        [SerializeField] private Sprite sprite;
    }
}
