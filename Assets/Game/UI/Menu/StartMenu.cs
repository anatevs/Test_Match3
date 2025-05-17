using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using GameManagement;

namespace GameCore {
    public class StartMenu : MonoBehaviour,
        IWinGameListener,
        ILoseGameListener
    {
        public event Action OnStartClicked;

        [SerializeField]
        private TMP_Text _titleText;

        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private string _winTitle = "You Win!";

        [SerializeField]
        private string _loseTitle = "You Lose!";


        private void Awake()
        {
            SetEmptyTitle();

            Show();
        }

        public void WinGame()
        {
            SetWinTitle();

            Show();
        }

        public void LoseGame()
        {
            SetLoseTitle();

            Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);

            _startButton.onClick.AddListener(OnStartButtonClick);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }

        public void SetWinTitle()
        {
            SetTitle(_winTitle);
        }

        public void SetLoseTitle()
        {
            SetTitle(_loseTitle);
        }

        public void SetEmptyTitle()
        {
            SetTitle(string.Empty);
        }

        private void SetTitle(string title)
        {
            _titleText.text = title;
        }

        private void OnDisable()
        {
            Hide();
        }

        private void OnStartButtonClick()
        {
            OnStartClicked?.Invoke();

            Hide();
        }
    }
}