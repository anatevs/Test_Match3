using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ColorsConfig",
        menuName = "Configs/Items/Colors")]
    public class ColorsConfig : ScriptableObject
    {
        public int IdLength => _colors.Length;

        [SerializeField]
        private Color[] _colors;

        public Color GetColor(int id)
        {
            return _colors[id];
        }

        public string GetColorName(int id)
        {
            return _colors[id].ToString();
        }
    }
}