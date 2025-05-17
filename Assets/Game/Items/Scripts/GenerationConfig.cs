using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "GenerationConfig",
        menuName = "Configs/Items/Generation")]
    public class GenerationConfig : ScriptableObject
    {
        public int TypesAmount => _typesAmount;
        public float XPos => Random.Range(_xRangeGen[0], _xRangeGen[1]);
        public float YPos => _yPos;
        public float ZRot => Random.Range(_zRotRange[0], _zRotRange[1]);
        public float TimeGen => _timeGen;

        [SerializeField]
        private int _typesAmount = 10;

        [SerializeField]
        private float[] _xRangeGen = new float[2];

        [SerializeField]
        private float _yPos;

        [SerializeField]
        private float[] _zRotRange = new float[2] { 0, 360 };

        [SerializeField]
        private float _timeGen = 5f;
    }
}