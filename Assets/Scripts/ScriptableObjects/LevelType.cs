using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelType", menuName = "ScriptableObjects/LevelType", order = 0)]
    public class LevelType : ScriptableObject
    {
        public int Columns { get { return _columns; } }
        public int Rows { get { return _rows; } }
        public int CellSize { get { return _cellSize; } }
        public int LevelTypeIndex { get { return _levelTypeIndex; } }
		
        [SerializeField] private int _columns;
        [SerializeField] private int _rows;
        [SerializeField] private int _cellSize = 64;
        [SerializeField] private int _levelTypeIndex = 0;

    }
}
