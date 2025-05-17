using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class ItemsGenerator : MonoBehaviour
    {
        [SerializeField]
        private ItemsPool _itemsPool;

        [SerializeField]
        private GenerationConfig _generationConfig;

        private readonly List<ItemData> _itemsData = new();

        private readonly int _itemsTypeMultiplier = 3;

        private readonly HashSet<Item> _fieldItemsSet = new();

        private void Awake()
        {
            StartCoroutine(GenerateItems(_generationConfig.TypesAmount));
        }

        public void RemoveFromField(Item item)
        {
            if (_fieldItemsSet.Contains(item))
            {
                _fieldItemsSet.Remove(item);

                item.SetInteractionActive(false);

                _itemsPool.Unspawn(item);
            }
        }

        private IEnumerator GenerateItems(int typesAmount)
        {
            var itemsAmount = typesAmount * _itemsTypeMultiplier;

            _itemsData.Clear();
            _itemsData.Capacity = itemsAmount;

            for (int i = 0; i < typesAmount; i++)
            {
                int shapeId = Random.Range(0, _itemsPool.ParamsLength.Shape);
                int colorId = Random.Range(0, _itemsPool.ParamsLength.Color);
                int avatarId = Random.Range(0, _itemsPool.ParamsLength.Avatar);

                for (int j = 0; j < _itemsTypeMultiplier; j++)
                {
                    _itemsData.Add(new ItemData(shapeId, colorId, avatarId));
                }
            }


            var deltaTime = _generationConfig.TimeGen / itemsAmount;

            for (int i = 0; i < itemsAmount; i++)
            {
                int randomIndex = Random.Range(0, _itemsData.Count);

                var pos = new Vector2(
                    _generationConfig.XPos,
                    _generationConfig.YPos);

                var rotZ = _generationConfig.ZRot;

                var item = _itemsPool.Spawn(_itemsData[randomIndex], pos, rotZ);

                _fieldItemsSet.Add(item);

                _itemsData.RemoveAt(randomIndex);

                yield return new WaitForSeconds(deltaTime);
            }
        }
    }
}