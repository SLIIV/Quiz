using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellsGenerator : MonoBehaviour
{
    public OnPullGenerated OnPullGenerated { get { return _onPullGenerated; } }
    public List<GameObject> CreatedCells { get { return _createdCells; } }
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private ObjectPulls[] _objectsPull;
    [SerializeField] private LevelScaler _levelScaler;
    [SerializeField] private int _objectsTypeIndex;
    private List<ObjectInCell> _generatedPull = new List<ObjectInCell>();
    private List<GameObject> _createdCells = new List<GameObject>();
    private OnPullGenerated _onPullGenerated = new OnPullGenerated();
    
    public void GenerateLevelPull()
    {
        _generatedPull.Clear();
        ScriptableObjects.LevelType level = _levelScaler.LevelChanger.Levels[_levelScaler.LevelChanger.CurrentLevel];
        int objectsCount = level.Columns * level.Rows;
        List<int> addedObjectsIndex = new List<int>();
        for(int i = 0; i < objectsCount; i++)
        {
            if(_objectsPull[_objectsTypeIndex].Pull.Count < objectsCount)
            {
                Debug.LogError("Ошибка в создании уровня: недостаточно объектов для создания уровня");
                break;
            }
            int randomIndexInPull = Random.Range(0, _objectsPull[_objectsTypeIndex].Pull.Count);
            if(addedObjectsIndex.Contains(randomIndexInPull))
            {
                i--;
                continue;
            }
            else
            {
                addedObjectsIndex.Add(randomIndexInPull);
                _generatedPull.Add(_objectsPull[_objectsTypeIndex].Pull[randomIndexInPull]);
            }
        }
        
    }
	
    public void ShowGeneratedPull()
    {
        _createdCells.Clear();
        for(int i = 0; i < _generatedPull.Count; i++)
        {
            GameObject cellObject = Instantiate(_cellPrefab, Vector3.zero,
                                                Quaternion.Euler(0, 0, _generatedPull[i].Rotation),
                                                _levelScaler.GameZoneParent);
            cellObject.GetComponent<Cell>().ObjectImage.sprite = _generatedPull[i].Sprite;
            _createdCells.Add(cellObject);
            
        }
        _onPullGenerated.Invoke(_generatedPull);
    }

    public void DeleteGeneratedPull()
    {
        Cell[] cells = _levelScaler.GameZoneParent.GetComponentsInChildren<Cell>();
        for(int i = 0; i < cells.Length; i++)
        {
            Destroy(cells[i].gameObject);
        }
    }
}

[System.Serializable]
public struct ObjectPulls
{
    public List<ObjectInCell> Pull;
}

public class OnPullGenerated : UnityEvent<List<ObjectInCell>>
{

}
