﻿using GameManagement;
using UnityEngine;

namespace GameCore
{
    public class Player : MonoBehaviour,
        IPlayGameListener,
        IWinGameListener,
        ILoseGameListener
    {
        [SerializeField]
        private LayerMask _itemsLayer;

        [SerializeField]
        private ItemsGenerator _itemsGenerator;

        [SerializeField]
        private Bar _bar;

        private PlayerInputController _playerInput;

        public void PlayGame()
        {
            StartPlay();
        }

        public void WinGame()
        {
            StopPlay();
        }
        public void LoseGame()
        {
            StopPlay();
        }

        public void StartPlay()
        {
            _playerInput = new PlayerInputController();

            _playerInput.OnTapped += Tap;
        }

        public void StopPlay()
        {
            _playerInput.OnTapped -= Tap;
        }

        private void OnDestroy()
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