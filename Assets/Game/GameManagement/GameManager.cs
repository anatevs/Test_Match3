using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private ItemsGenerator _itemsGenerator;

        [SerializeField]
        private Player _player;

        [SerializeField]
        private Bar _bar;

        [SerializeField]
        private StartMenu _startMenu;

        private void Awake()
        {
            _startMenu.OnStartClicked += StartGame;

            _startMenu.SetEmptyTitle();

            _startMenu.Show();

            _bar.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _itemsGenerator.OnAllItemsStopped -= Play;

            _itemsGenerator.OnAllItemsUsed -= MakeOnWin;

            _bar.OnBarFull -= MakeOnLost;

            _startMenu.OnStartClicked -= StartGame;

            _startMenu.Hide();
        }


        private void MakeOnLost()
        {
            _itemsGenerator.OnAllItemsUsed -= MakeOnWin;

            _startMenu.SetLoseTitle();

            EndGame();
        }

        private void MakeOnWin()
        {
            _startMenu.SetWinTitle();

            EndGame();
        }

        private void EndGame()
        {
            _player.StopPlay();

            _startMenu.Show();

            _bar.gameObject.SetActive(false);
        }

        private void StartGame()
        {
            _startMenu.Hide();

            _itemsGenerator.Generate();

            _itemsGenerator.OnAllItemsUsed += MakeOnWin;

            _itemsGenerator.OnAllItemsStopped += Play;
        }

        private void Play()
        {
            _bar.gameObject.SetActive(true);

            _bar.OnBarFull += MakeOnLost;

            _player.StartPlay();

            _itemsGenerator.OnAllItemsStopped -= Play;
        }
    }
}