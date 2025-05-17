using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "AvatarsConfig",
        menuName = "Configs/Items/Avatars")]
    public class AvatarsConfig : ScriptableObject
    {
        public int IdLength => _avatars.Length;

        [SerializeField]
        private Sprite[] _avatars;

        public Sprite GetAvatar(int id)
        {
            return _avatars[id];
        }
    }
}