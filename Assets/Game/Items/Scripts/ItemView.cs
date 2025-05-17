using UnityEngine;

namespace GameCore
{
    public class ItemView : MonoBehaviour
    {
        public Sprite Shape => _background.sprite;

        public Color Color => _background.color;

        public Sprite Avatar => _avatar.sprite;

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