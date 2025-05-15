using System.Collections;
using UnityEngine;

namespace GameCore
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour
    {
        public int Shape => _shape;
        public int Color => _color;
        public int Avatar => _avatar;

        public bool IsPlayable => _isPlayable;

        [SerializeField]
        private ItemView _view;

        private int _shape;

        private int _color;

        private int _avatar;

        private bool _isPlayable;

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

        public bool IsEqual(Item other)
        {
            return _shape == other.Shape &&
                _color == other.Color &&
                _avatar == other.Avatar;
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

        public void SetInteractionActive(bool isActive)
        {
            _isPlayable = isActive;
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

        public void SetGravity(float gravity)
        {
            _rb.gravityScale = gravity;
        }
    }
}