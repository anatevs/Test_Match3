using System.Collections;
using UnityEngine;

namespace GameCore
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour
    {
        public ItemData IdData => new(_shape, _color, _avatar);

        public ItemView View => _view;

        [SerializeField]
        private ItemView _view;

        private int _shape;

        private int _color;

        private int _avatar;

        private Rigidbody2D _rb;

        private Collider2D _collider;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        public void Init(int shapeId)
        {
            _shape = shapeId;
        }

        public void SetColor(int colorId, Color color)
        {
            _color = colorId;

            _view.SetColor(color);
        }

        public void SetAvatar(int avatarId, Sprite sprite)
        {
            _avatar = avatarId;

            _view.SetAvatar(sprite);
        }

        public void SetPlayableState(bool isActive)
        {
            _collider.enabled = isActive;

            if (isActive)
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                _rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}