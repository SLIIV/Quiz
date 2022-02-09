using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelTaskGenerator : MonoBehaviour, ITaskGenerator
    {
        private List<string> _createdTasksObjects = new List<string>();
        private Task _currentTusk = new Task();
        
        public void GenerateTask(ICellsGeneratable cellsGenerator)
        {
            Task task = new Task();
            int randomObjectIndex;
            do
            {
                if(_createdTasksObjects.Count >= cellsGenerator.GeneratedPull().Count)
                {
                    Debug.LogError("Все задачи выполнены");
                    return;
                }
                randomObjectIndex = Random.Range(0, cellsGenerator.GeneratedPull().Count);
            }
            while(_createdTasksObjects.Contains(cellsGenerator.GeneratedPull()[randomObjectIndex].Name));
            task.ObjectNameToFind = cellsGenerator.GeneratedPull()[randomObjectIndex].Name;
            cellsGenerator.CreatedCells()[randomObjectIndex].GetComponent<Cell>().SetAnswerTrue();
            _currentTusk = task;
            _createdTasksObjects.Add(cellsGenerator.GeneratedPull()[randomObjectIndex].Name);
        }

        public Task GetCurrentTask()
        {
            return _currentTusk;
        }
    }

    public struct Task
    {
        public string ObjectNameToFind;
    }
}
