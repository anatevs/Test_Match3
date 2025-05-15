using UnityEngine;

namespace GameCore
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _background;

        [SerializeField]
        private SpriteRenderer _avatar;

        public void SetColor(Color color)
        {
            _background.color = color;
        }

        public void SetAvatar(Sprite sprite)
        {
            _avatar.sprite = sprite;
        }
    }
}