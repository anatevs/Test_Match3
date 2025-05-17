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
            Debug.Log("ResetUI started");
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            Debug.Log("ResetUI enabled");
            _button.onClick.AddListener(OnResetButtonClicked);
        }

        private void OnDisable()
        {
            Debug.Log("ResetUI disabled");
            _button.onClick.RemoveListener(OnResetButtonClicked);
        }

        private void OnResetButtonClicked()
        {
            Debug.Log("Reset button clicked");

            OnResetClicked?.Invoke();

            gameObject.SetActive(false);
        }
    }
}