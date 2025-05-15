using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCore
{
    public sealed class PlayerInputController :
        IDisposable
    {
        public event Action<Vector2> OnTapped;

        private GameControls _controls;

        private Camera _camera;

        public PlayerInputController()
        {
            Init();
        }

        public void Init()
        {
            _controls = new GameControls();

            _controls.Enable();

            _controls.Gameplay.Tap.performed += Tap;

            _camera = Camera.main;
        }

        void IDisposable.Dispose()
        {
            _controls.Gameplay.Tap.performed -= Tap;

            _controls.Disable();
        }

        private void Tap(InputAction.CallbackContext context)
        {
            var clickPositionScreen = context.ReadValue<Vector2>();

            var clickPos = _camera.ScreenToWorldPoint(clickPositionScreen);

            OnTapped?.Invoke(clickPos);
        }
    }
}