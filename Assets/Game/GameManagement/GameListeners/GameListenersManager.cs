using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public sealed class GameListenersManager : MonoBehaviour
    {
        private readonly List<IGameListener> _gameListeners = new();

        private readonly List<IStartGameListener> _startGameListeners = new();

        private readonly List<IPlayGameListener> _playGameListeners = new();

        private readonly List<IWinGameListener> _winGameListeners = new();

        private readonly List<ILoseGameListener> _loseGameListeners = new();

        public void AddListeners(GameObject[] rootGameObjects)
        {
            for (int i = 0; i < rootGameObjects.Length; i++)
            {
                AddListeners(rootGameObjects[i]);
            }
        }

        public void AddListeners(GameObject go)
        {
            IGameListener[] listeners =
                go.GetComponentsInChildren<IGameListener>(true);

            AddListeners(listeners);
        }

        public void AddListeners(IEnumerable<IGameListener> listeners)
        {
            foreach (IGameListener listener in listeners)
            {
                AddListener(listener);
            }
        }

        public void AddListener(IGameListener listener)
        {
            _gameListeners.Add(listener);

            if (listener is IStartGameListener startListener)
            {
                _startGameListeners.Add(startListener);
            }

            if (listener is IPlayGameListener playListener)
            {
                _playGameListeners.Add(playListener);
            }

            if (listener is IWinGameListener winGameListener)
            {
                _winGameListeners.Add(winGameListener);
            }

            if (listener is ILoseGameListener loseGameListener)
            {
                _loseGameListeners.Add(loseGameListener);
            }
        }

        public void OnStartGame()
        {
            foreach (var listener in _startGameListeners)
            {
                listener.StartGame();
            }
        }

        public void OnPlayGame()
        {
            foreach (var listener in _playGameListeners)
            {
                listener.PlayGame();
            }
        }

        public void OnWinGame()
        {
            foreach (var listener in _winGameListeners)
            {
                listener.WinGame();
            }
        }

        public void OnLoseGame()
        {
            foreach (var listener in _loseGameListeners)
            {
                listener.LoseGame();
            }
        }
    }
}