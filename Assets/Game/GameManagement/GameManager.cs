using GameManagement;
using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameListenersManager _listenersManager;

        [SerializeField]
        private ItemsGenerator _itemsGenerator;

        [SerializeField]
        private Player _player;

        [SerializeField]
        private Bar _bar;

        [SerializeField]
        private StartMenu _startMenu;

        private void Start()
        {
            _startMenu.OnStartClicked += _listenersManager.OnStartGame;

            _itemsGenerator.OnAllItemsStopped += _listenersManager.OnPlayGame;

            _itemsGenerator.OnAllItemsUsed += _listenersManager.OnWinGame;

            _bar.OnBarFull += _listenersManager.OnLoseGame;
        }

        private void OnDisable()
        {
            _startMenu.OnStartClicked -= _listenersManager.OnStartGame;

            _itemsGenerator.OnAllItemsStopped -= _listenersManager.OnPlayGame;

            _itemsGenerator.OnAllItemsUsed -= _listenersManager.OnWinGame;

            _bar.OnBarFull -= _listenersManager.OnLoseGame;
        }
    }
}