using GameManagement;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class ResetUI : MonoBehaviour,
        IPlayGameListener,
        IWinGameListener,
        ILoseGameListener
    {
        public event Action OnResetClicked;

        [SerializeField]
        private Button _button;

        public void PlayGame()
        {
            gameObject.SetActive(true);
        }

        public void WinGame()
        {
            gameObject.SetActive(false);
        }

        public void LoseGame()
        {
            gameObject.SetActive(false);
        }

        private void Start()
        {
            gameObject.SetActive(false);

            _button.onClick.AddListener(OnResetButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnResetButtonClicked);
        }

        private void OnResetButtonClicked()
        {
            OnResetClicked?.Invoke();
        }
    }
}