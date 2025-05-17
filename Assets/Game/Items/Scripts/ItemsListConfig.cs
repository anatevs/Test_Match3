using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ItemsListConfig",
        menuName = "Configs/Items/ItemsListConfig")]
    public class ItemsListConfig : ScriptableObject
    {
        public int IdLength => _items.Length;

        [SerializeField]
        private ItemConfig[] _items;

        public Item GetItem(int shapeId)
        {
            return _items[shapeId].GetPrefab();
        }
    }
}