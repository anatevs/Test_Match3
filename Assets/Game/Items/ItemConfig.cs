using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ItemConfig",
        menuName = "Configs/Items/ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        public string ShapeName => _shapeName;

        [SerializeField]
        private string _shapeName;

        [SerializeField]
        private GameObject _prefab;
    }
}