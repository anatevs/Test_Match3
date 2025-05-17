using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ItemConfig",
        menuName = "Configs/Items/ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField]
        private string _shapeName;

        [SerializeField]
        private Item _prefab;

        public Item GetPrefab()
        {
            return _prefab;
        }
    }
}