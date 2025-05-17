using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class BarPlace : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inactiveView;

        [SerializeField]
        private BarItemView _activeView;

        public void SetActiveView(Sprite background, Color color, Sprite avatar)
        {
            _activeView.SetImage(background, color, avatar);

            _activeView.gameObject.SetActive(true);

            _inactiveView.SetActive(false);
        }

        public void SetInactiveView()
        {
            _activeView.gameObject.SetActive(false);
            _inactiveView.SetActive(true);
        }
    }
}