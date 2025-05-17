using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class ItemsPool : MonoBehaviour
    {
        public ParamsLength ParamsLength => _paramsLength;

        [SerializeField]
        private ItemsListConfig _itemsListConfig;

        [SerializeField]
        private ColorsConfig _colorsConfig;

        [SerializeField]
        private AvatarsConfig _avatarsConfig;

        [SerializeField]
        private Transform _parent;

        private Queue<Item>[] _itemShapeLists;

        private ParamsLength _paramsLength;

        private void Awake()
        {
            _itemShapeLists = new Queue<Item>[_itemsListConfig.IdLength];

            for (int i = 0; i < _itemShapeLists.Length; i++)
            {
                _itemShapeLists[i] = new Queue<Item>();
            }

            _paramsLength = new ParamsLength(_itemsListConfig.IdLength,
                _colorsConfig.IdLength,
                _avatarsConfig.IdLength);
        }

        public Item Spawn(ItemData itemData, Vector2 pos, float rotZ)
        {
            if (!_itemShapeLists[itemData.ShapeId].TryDequeue(out var item))
            {
                item = Instantiate(_itemsListConfig.GetItem(itemData.ShapeId));
            }

            item.SetColor(itemData.ColorId, _colorsConfig.GetColor(itemData.ColorId));

            item.SetAvatar(itemData.AvatarId, _avatarsConfig.GetAvatar(itemData.AvatarId));

            item.transform.SetParent(_parent);

            item.transform.SetPositionAndRotation(
                pos,
                Quaternion.Euler(0, 0, rotZ));

            item.gameObject.SetActive(true);

            item.SetInteractionActive(true);

            return item;
        }

        public void Unspawn(Item item)
        {
            item.gameObject.SetActive(false);

            _itemShapeLists[item.IdData.ShapeId].Enqueue(item);
        }
    }

    public struct ParamsLength
    {
        public int Shape;
        public int Color;
        public int Avatar;
        public ParamsLength(int shapesLength, int colorsLength, int avatarsLength)
        {
            Shape = shapesLength;
            Color = colorsLength;
            Avatar = avatarsLength;
        }
    }
}