using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelTaskGenerator : MonoBehaviour
{
    public Task CurrentTusk { get { return _currentTusk; } }
    public UnityEvent OnTaskGenerated { get { return _onTaskGenerated; } }
    [SerializeField] private CellsGenerator _cellsGenerator;
    private List<string> _createdTasksObjects = new List<string>();
    private Task _currentTusk = new Task();
    private UnityEvent _onTaskGenerated = new UnityEvent();

    public void AddListenersOnEvents()
    {
        _cellsGenerator.OnPullGenerated.AddListener((generatedPull) => GenerateTask(generatedPull));
    }
	
    public void GenerateTask(List<ObjectInCell> generatedPull)
    {
        Task task = new Task();
        int randomObjectIndex;
        do
        {
            if(_createdTasksObjects.Count >= generatedPull.Count)
            {
                Debug.LogError("Все задачи выполнены");
                return;
            }
            randomObjectIndex = Random.Range(0, generatedPull.Count);
        }
        while(_createdTasksObjects.Contains(generatedPull[randomObjectIndex].Name));
        task.ObjectNameToFind = generatedPull[randomObjectIndex].Name;
        _cellsGenerator.CreatedCells[randomObjectIndex].GetComponent<Cell>().SetAnswerTrue();
        _currentTusk = task;
        _createdTasksObjects.Add(generatedPull[randomObjectIndex].Name);
        _onTaskGenerated.Invoke();
    }
	
    private void OnDisable()
    {
        _cellsGenerator.OnPullGenerated.RemoveListener((generatedPull) => GenerateTask(generatedPull));
    }
}

public struct Task
{
    public string ObjectNameToFind;
}
