using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Level
{
    public class LevelChanger : MonoBehaviour
    {
        public ScriptableObjects.LevelType[] Levels { get { return _levels; } }
        public int CurrentLevel { get { return _currentLevel; } }
        [SerializeField] private ScriptableObjects.LevelType[] _levels;
        [SerializeField] private int _startLevel;
        [SerializeField] private float _loadLevelDelay;
        [SerializeField] private GameObject _cellsGeneratorObject;
        [SerializeField] private GameObject _taskGeneratorObject;
        [SerializeField] private GameObject _gameZoneObject;
        [SerializeField] private GameObject _levelTaskUIObject;
        [SerializeField] private GameObject _UIObject;
        [SerializeField] private GameObject _cellEffectsObject;
        private ILevelScaleble _gameZone;
        private int _currentLevel;
        private ITaskGenerator _taskGenerator;
        private ICellsGeneratable _cellsGenerator;
        private IUIButtons _UIButtons;
        private ILevelTaskUI _levelTaskUI;
        private ICellEffect _cellEffects;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _taskGenerator = _taskGeneratorObject.GetComponent<ITaskGenerator>();
            if(_taskGenerator == null)
            {
                ThrowNullException(_taskGeneratorObject);
            }
            _gameZone = _gameZoneObject.GetComponent<ILevelScaleble>();
            if(_gameZone == null)
            {
                ThrowNullException(_gameZoneObject);
            }
            _cellsGenerator = _cellsGeneratorObject.GetComponent<ICellsGeneratable>();
            if(_cellsGenerator == null)
            {
                ThrowNullException(_cellsGeneratorObject);
            }
            _UIButtons = _UIObject.GetComponent<IUIButtons>();
            if(_UIButtons == null)
            {
                ThrowNullException(_UIObject);
            }
            _levelTaskUI = _levelTaskUIObject.GetComponent<ILevelTaskUI>();
            if(_levelTaskUI == null)
            {
                ThrowNullException(_levelTaskUIObject);
            }
            _cellEffects = _cellEffectsObject.GetComponent<ICellEffect>();
            AnswerClick.GetTrueAnswerEvent().AddListener((cell) => StartCoroutine(LoadLevelByDelay(cell)));
            SetStartLevel();
        }

        private void ThrowNullException(GameObject var)
        {
            throw new System.Exception($"Null reference exception. {var.name} not cotains interface");
        }
		
        private void SetStartLevel()
        {
            _currentLevel = _startLevel;
            InitializeLevel();
            _cellEffects.PlayStartAnimation(_cellsGenerator);
        }
        
        private void NextLevel()
        {
            if(_currentLevel < Levels.Length - 1)
            {
                _currentLevel++;
                _cellsGenerator.DeleteGeneratedPull(_gameZone);
                InitializeLevel();
            }
            else
            {
                _UIButtons.ShowRestartButton();
            }
        }

        private void InitializeLevel()
        {
            _cellsGenerator.GenerateLevelPull(Levels[_currentLevel]);
            _gameZone.ScaleLevel(Levels[_currentLevel]);
            _cellsGenerator.ShowGeneratedPull(_gameZone);
            _taskGenerator.GenerateTask(_cellsGenerator);
            ChangeUI();
        }
        
        private void ChangeUI()
        {
            _levelTaskUI.ChangeTask(_taskGenerator);
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
}
