using GameManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class ItemsGenerator : MonoBehaviour,
        IStartGameListener
    {
        public event Action OnAllItemsStopped;

        public event Action OnAllItemsUsed;

        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private ItemsPool _itemsPool;

        [SerializeField]
        private GenerationConfig _generationConfig;

        private readonly List<ItemData> _itemsData = new();

        private readonly int _itemsTypeMultiplier = 3;

        private readonly HashSet<Item> _fieldItemsSet = new();

        private Rigidbody2D _lastRb;

        private readonly float _stopVelocityY = -1e-5f;

        public void StartGame()
        {
            Generate();
        }

        public void Generate()
        {
            foreach (var item in _fieldItemsSet)
            {
                DisactivateItem(item);
            }

            _fieldItemsSet.Clear();

            StartCoroutine(GenerateItems(_generationConfig.TypesAmount));
        }

        public void RemoveFromField(Item item)
        {
            if (_fieldItemsSet.Contains(item))
            {
                _fieldItemsSet.Remove(item);

                DisactivateItem(item);
            }

            if (_fieldItemsSet.Count == 0)
            {
                OnAllItemsUsed?.Invoke();
            }
        }

        private void DisactivateItem(Item item)
        {
            item.SetPlayableState(false);

            _itemsPool.Unspawn(item);
        }

        private IEnumerator GenerateItems(int typesAmount)
        {
            var itemsAmount = typesAmount * _itemsTypeMultiplier;

            _itemsData.Clear();
            _itemsData.Capacity = itemsAmount;

            for (int i = 0; i < typesAmount; i++)
            {
                int shapeId = UnityEngine.Random.Range(0, _itemsPool.ParamsLength.Shape);
                int colorId = UnityEngine.Random.Range(0, _itemsPool.ParamsLength.Color);
                int avatarId = UnityEngine.Random.Range(0, _itemsPool.ParamsLength.Avatar);

                for (int j = 0; j < _itemsTypeMultiplier; j++)
                {
                    _itemsData.Add(new ItemData(shapeId, colorId, avatarId));
                }
            }


            var deltaTime = _generationConfig.TimeGen / itemsAmount;

            for (int i = 0; i < itemsAmount; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, _itemsData.Count);

                var pos = new Vector2(
                    _generationConfig.XPos,
                    _generationConfig.YPos);

                var rotZ = _generationConfig.ZRot;

                var item = _itemsPool.Spawn(_itemsData[randomIndex], pos, rotZ);

                _fieldItemsSet.Add(item);

                _itemsData.RemoveAt(randomIndex);

                yield return new WaitForSeconds(deltaTime);

                if (i == itemsAmount - 1)
                {
                    _lastRb = item.GetComponent<Rigidbody2D>();
                }
            }
        }

        private void FixedUpdate()
        {
            if (_lastRb != null)
            {
                if (_lastRb.velocity.y >= _stopVelocityY)
                {
                    OnAllItemsStopped?.Invoke();

                    _lastRb = null;
                }
            }
        }
    }
}