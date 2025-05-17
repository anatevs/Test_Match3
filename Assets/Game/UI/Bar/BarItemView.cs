using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class BarItemView : MonoBehaviour
    {
        [SerializeField]
        private Image _background;

        [SerializeField]
        private Image _avatar;

        public void SetImage(Sprite background, Color color, Sprite avatar)
        {
            _background.overrideSprite = background;

            _background.color = color;

            _avatar.overrideSprite = avatar;
        }
    }
}