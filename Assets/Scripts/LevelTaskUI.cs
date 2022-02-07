using UnityEngine;
using UnityEngine.UI;

public class LevelTaskUI : MonoBehaviour
{
    [SerializeField] private LevelTaskGenerator _taskGenerator;
    [SerializeField] private Text _taskName;
    
    public void AddListenersOnEvents()
    {
        _taskGenerator.OnTaskGenerated.AddListener(() => ChangeTask());
    }
	
    private void ChangeTask()
    {
        _taskName.text = _taskGenerator.CurrentTusk.ObjectNameToFind;
    }
	
    private void OnDisable() 
    {
        _taskGenerator.OnTaskGenerated.RemoveListener(() => ChangeTask());
    }
}
