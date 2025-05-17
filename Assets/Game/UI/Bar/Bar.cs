using GameManagement;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class Bar : MonoBehaviour,
        IStartGameListener,
        IPlayGameListener,
        IWinGameListener,
        ILoseGameListener
    {
        public event Action OnBarFull;

        [SerializeField]
        private BarView _barView;

        private int _barLength;

        private readonly List<ItemData> _itemsData = new();

        private readonly Dictionary<ItemData, List<int>> _typeDict = new();

        private int _currentMaxIndex = -1;

        private readonly int _removeOrder = 3;

        private readonly List<int[]> _shiftInfo = new();

        private void Awake()
        {
            _barLength = _barView.BarLength;
        }

        public void StartGame()
        {
            ClearBar();

            gameObject.SetActive(false);
        }

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

        public void ClearBar()
        {
            _currentMaxIndex = -1;

            _itemsData.Clear();

            _typeDict.Clear();

            _barView.ClearView();
        }

        public void AddAndUpdate(Item item)
        {
            _currentMaxIndex++;

            _itemsData.Add(item.IdData);

            if (_typeDict.ContainsKey(item.IdData))
            {
                _typeDict[item.IdData].Add(_currentMaxIndex);
            }
            else
            {
                _typeDict[item.IdData] = new List<int> { _currentMaxIndex};
            }

            _barView.SetActiveView(_currentMaxIndex,
                item.View.Shape,
                item.View.Color,
                item.View.Avatar);

            if (_typeDict[item.IdData].Count == _removeOrder)
            {
                _shiftInfo.Clear();

                if (_currentMaxIndex + 1 != _removeOrder)
                {
                    int count = 0;

                    for (int i = _removeOrder - 1; i >= 0; i--)
                    {
                        var removeIndex = _typeDict[item.IdData][i];

                        var rightIndex = _currentMaxIndex;

                        if (i < _removeOrder - 1)
                        {
                            rightIndex = _typeDict[item.IdData][i + 1];
                        }

                        if (rightIndex - removeIndex > 1)
                        {
                            for (int j = rightIndex - 1; j > removeIndex; j--)
                            {
                                var toIndex = j - (_removeOrder - count);

                                _shiftInfo.Add(new int[] { j, toIndex });

                                var listIndex = _typeDict[_itemsData[j]].IndexOf(j);

                                _typeDict[_itemsData[j]][listIndex] = toIndex;
                            }
                        }

                        count++;
                    }
                }

                _barView.ShiftViews(_typeDict[item.IdData], _shiftInfo, _currentMaxIndex);

                _itemsData.RemoveAll(x => (x.ShapeId == item.IdData.ShapeId &&
                x.ColorId == item.IdData.ColorId &&
                x.AvatarId == item.IdData.AvatarId));

                _currentMaxIndex -= _removeOrder;

                _typeDict.Remove(item.IdData);
            }

            else
            {
                if (_currentMaxIndex == _barLength - 1)
                {
                    ClearBar();

                    OnBarFull?.Invoke();

                    return;
                }
            }
        }

        
    }
}