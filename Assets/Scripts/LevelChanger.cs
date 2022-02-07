using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    public ScriptableObjects.LevelType[] Levels { get { return _levels; } }
    public int CurrentLevel { get { return _currentLevel; } }
    public UnityEvent OnGameOver { get { return _onGameOver; } }
    [SerializeField] private ScriptableObjects.LevelType[] _levels;
    [SerializeField] private int _startLevel;
    [SerializeField] private float _loadLevelDelay;
    [SerializeField] private LevelScaler _levelScaler;
    [SerializeField] private CellsGenerator _cellsGenerator;
    private int _currentLevel;
    private UnityEvent _onGameOver = new UnityEvent();

    public void Initialize()
    {
        SetStartLevel();
        AddListenersOnEvents();
    }

    private void SetStartLevel()
    {
        _currentLevel = _startLevel;
    }
	
    private void AddListenersOnEvents()
    {
        AnswerClick.GetTrueAnswerEvent().AddListener((cell) => StartCoroutine(LoadLevelByDelay(cell)));
    }
	
    private void NextLevel()
    {
        if(_currentLevel < Levels.Length - 1)
        {
            _currentLevel++;
            _cellsGenerator.GenerateLevelPull();
            _cellsGenerator.DeleteGeneratedPull();
            _levelScaler.ScaleLevel();
            _cellsGenerator.ShowGeneratedPull();
        }
        else
        {
            OnGameOver.Invoke();
        }
    }

    private void OnDisable() 
    {
        AnswerClick.GetTrueAnswerEvent().RemoveListener((cell) => StartCoroutine(LoadLevelByDelay(cell)));
    }

    private IEnumerator LoadLevelByDelay(GameObject cell)
    {
        cell.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(_loadLevelDelay);
        NextLevel();
        
    }
}
