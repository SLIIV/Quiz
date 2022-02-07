using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private CellsGenerator _cellsGenerator;
    [SerializeField] private LevelTaskGenerator _levelTaskGenerator;
    [SerializeField] private LevelTaskUI _levelTaskUI;
    [SerializeField] private LevelScaler _levelScaler;
    [SerializeField] private LevelChanger _levelChanger;
	
    private void Start()
    {
        _levelScaler.ScaleLevel();
        _levelChanger.Initialize();
        _levelTaskGenerator.AddListenersOnEvents();
        _levelTaskUI.AddListenersOnEvents();
        _cellsGenerator.GenerateLevelPull();
        _cellsGenerator.ShowGeneratedPull(); 
    }
}
