using UnityEngine;

namespace GameManagement
{
    public sealed class GameListenersInstaller : MonoBehaviour
    {
        [SerializeField]
        private GameListenersManager _listenersManager;

        private void Awake()
        {
            var sceneObjects = gameObject.scene.GetRootGameObjects();

            _listenersManager.AddListeners(sceneObjects);
        }
    }
}