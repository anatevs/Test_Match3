using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ItemsListConfig",
        menuName = "Configs/Items/ItemsListConfig")]
    public class ItemsListConfig : ScriptableObject
    {
        public int IdLength => _items.Length;

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

                    _items[i].SetShapeId(i);
                }
            }
        }

        public Item GetItem(int shapeId)
        {
            return _items[shapeId].GetPrefab();
        }

        public string GetShapeName(int shapeId)
        {
            return _items[shapeId].ShapeName;
        }
    }
}