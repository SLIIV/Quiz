using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Level
{
    public class CellsGenerator : MonoBehaviour, ICellsGeneratable
    {
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private ObjectPulls[] _objectsPull;
        private List<ScriptableObjects.ObjectInCell> _generatedPull = new List<ScriptableObjects.ObjectInCell>();
        private List<GameObject> _createdCells = new List<GameObject>();
        
        public void GenerateLevelPull(ScriptableObjects.LevelType level)
        {
            _generatedPull.Clear();
            int objectsCount = level.Columns * level.Rows;
            List<int> addedObjectsIndex = new List<int>();
            for(int i = 0; i < objectsCount; i++)
            {
                if(_objectsPull[level.LevelTypeIndex].Pull.Count < objectsCount)
                {
                    Debug.LogError("Ошибка в создании уровня: недостаточно объектов для создания уровня");
                    break;
                }
                int randomIndexInPull = Random.Range(0, _objectsPull[level.LevelTypeIndex].Pull.Count);
                if(addedObjectsIndex.Contains(randomIndexInPull))
                {
                    i--;
                    continue;
                }
                else
                {
                    addedObjectsIndex.Add(randomIndexInPull);
                    _generatedPull.Add(_objectsPull[level.LevelTypeIndex].Pull[randomIndexInPull]);
                }
            }
        }
        
        public void ShowGeneratedPull(ILevelScaleble gameZone)
        {
            _createdCells.Clear();
            for(int i = 0; i < _generatedPull.Count; i++)
            {
                GameObject cellObject = Instantiate(_cellPrefab, Vector3.zero,
                                                    Quaternion.Euler(0, 0, _generatedPull[i].Rotation),
                                                    gameZone.GetTransform());
                cellObject.GetComponent<Cell>().ObjectImage.sprite = _generatedPull[i].Sprite;
                _createdCells.Add(cellObject);
                
            }
        }

        public void DeleteGeneratedPull(ILevelScaleble gameZone)
        {
            Cell[] cells = gameZone.GetTransform().GetComponentsInChildren<Cell>();
            for(int i = 0; i < cells.Length; i++)
            {
                Destroy(cells[i].gameObject);
            }
        }

        List<ObjectInCell> ICellsGeneratable.GeneratedPull()
        {
            return _generatedPull;
        }

        List<GameObject> ICellsGeneratable.CreatedCells()
        {
            return _createdCells;
        }
    }

    [System.Serializable]
    public struct ObjectPulls
    {
        public List<ScriptableObjects.ObjectInCell> Pull;
    }
}
