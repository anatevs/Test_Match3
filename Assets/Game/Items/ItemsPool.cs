using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class ItemsPool : MonoBehaviour
    {
        [SerializeField]
        private ItemsListConfig _itemsListConfig;

        [SerializeField]
        private ColorsConfig _colorsConfig;

        [SerializeField]
        private AvatarsConfig _avatarsConfig;

        private Queue<Item>[] _itemShapeLists;


        private void Awake()
        {
            _itemShapeLists = new Queue<Item>[_itemsListConfig.MaxId];

            for (int i = 0; i < _itemShapeLists.Length; i++)
            {
                _itemShapeLists[i] = new Queue<Item>();
            }
        }

        public Item Spawn(int shapeId, int colorId, int avatarId)
        {
            if (!_itemShapeLists[shapeId].TryDequeue(out var item))
            {
                item = Instantiate(_itemsListConfig.GetItem(shapeId));
            }

            item.SetColor(colorId, _colorsConfig.GetColor(colorId));

            item.SetAvatar(avatarId, _avatarsConfig.GetAvatar(avatarId));

            

            item.gameObject.SetActive(true);

            item.SetInteractionActive(true);

            return item;
        }

        public void Unspawn(Item item)
        {
            //disable item

            _itemShapeLists[item.Shape].Enqueue(item);
        }
    }
}