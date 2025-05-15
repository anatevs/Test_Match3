using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ItemsListConfig",
        menuName = "Configs/Items/ItemConfig")]
    public class ItemsListConfig : ScriptableObject
    {
        public string[] ShapeNames => _shapeNames;

        [SerializeField]
        private ItemConfig[] _items;

        private string[] _shapeNames;

        private readonly Dictionary<string, ItemConfig> _itemDictionary = new();

        public void Init()
        {
            _shapeNames = new string[_items.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                if (!_itemDictionary.TryAdd(_items[i].ShapeName, _items[i]))
                {
                    Debug.LogWarning($"Duplicate item found: {_items[i].ShapeName}");
                }
                else
                {
                    _shapeNames[i] = _items[i].ShapeName;
                }
            }
        }

        public ItemConfig GetItem(string shapeName)
        {
            if (!_itemDictionary.TryGetValue(shapeName, out var item))
            {
                Debug.LogWarning($"Item not found: {shapeName}");
            }

            return item;
        }
    }
}