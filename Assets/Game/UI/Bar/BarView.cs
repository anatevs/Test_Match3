using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class BarView : MonoBehaviour
    {
        public int BarLength => _barPlaces.Length;

        [SerializeField]
        private BarPlace[] _barPlaces;

        private float[] _xPositions;

        private Vector3[] _placePositions;

        private void Awake()
        {
            foreach (var barPlace in _barPlaces)
            {
                barPlace.SetInactiveView();
            }

            _xPositions = new float[_barPlaces.Length];

            _placePositions = new Vector3[_barPlaces.Length];

            for (int i = 0; i < _barPlaces.Length; i++)
            {
                _xPositions[i] = _barPlaces[i].transform.localPosition.x;

                _placePositions[i] = _barPlaces[i].transform.localPosition;
            }
        }

        public void SetActiveView(int index, Sprite background, Color color, Sprite avatar)
        {
            if (index < 0 || index >= _barPlaces.Length)
            {
                Debug.LogError("Index out of bounds");
                return;
            }

            _barPlaces[index].SetActiveView(background, color, avatar);
        }

        public void SetInactiveView(int index)
        {
            if (index < 0 || index >= _barPlaces.Length)
            {
                Debug.LogError("Index out of bounds");
                return;
            }

            _barPlaces[index].SetInactiveView();
        }

        public void ShiftViews(List<int> removeIndexes, List<int[]> shiftInfo, int currentMaxIndex)
        {
            var removedPlaces = new BarPlace[removeIndexes.Count];

            for (int i = 0; i < removedPlaces.Length; i++)
            {
                _barPlaces[removeIndexes[i]].SetInactiveView();

                removedPlaces[i] = _barPlaces[removeIndexes[i]];
            }

            for (int i = shiftInfo.Count - 1; i >= 0; i--)
            {
                var shift = shiftInfo[i];

                var fromIndex = shift[0];
                var toIndex = shift[1];

                _barPlaces[fromIndex].transform.localPosition = _placePositions[toIndex]; //view

                _barPlaces[toIndex] = _barPlaces[fromIndex];
            }

            for (int i = 0; i < removedPlaces.Length; i++)
            {
                if (shiftInfo.Count > 0)
                {
                    var inactiveIndex = currentMaxIndex - i;

                    _barPlaces[inactiveIndex] = removedPlaces[i];

                    _barPlaces[inactiveIndex].transform.localPosition = _placePositions[inactiveIndex];
                }
            }
        }
    }
}