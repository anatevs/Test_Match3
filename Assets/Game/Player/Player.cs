using System;
using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _itemsLayer;

        [SerializeField]
        private ItemsGenerator _itemsGenerator;

        [SerializeField]
        private Bar _bar;

        private PlayerInputController _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInputController();

            _playerInput.OnTapped += Tap;
        }

        private void OnDisable()
        {
            _playerInput.OnTapped -= Tap;
        }

        private void Tap(Vector2 clickPos)
        {
            var collider = Physics2D.OverlapPoint(clickPos, _itemsLayer);

            if (collider != null)
            {
                var item = collider.GetComponent<Item>();

                _itemsGenerator.RemoveFromField(item);

                _bar.AddAndUpdate(item);
            }
        }
    }
}