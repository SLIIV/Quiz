using UnityEngine;

public class LevelScaler : MonoBehaviour
{
    public LevelChanger LevelChanger { get { return _levelChanger; } }
    public Transform GameZoneParent { get { return this._gameZoneParent; } }
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private Transform _gameZoneParent;

    public void ScaleLevel()
    {
        ScriptableObjects.LevelType level = LevelChanger.Levels[LevelChanger.CurrentLevel];
        RectTransform rectTransform = _gameZoneParent.GetComponent<RectTransform>();
        float weight = level.Columns * level.CellSize;
        float height = level.Rows * level.CellSize;
        rectTransform.sizeDelta = new Vector2(weight, height);
        
    }
}
