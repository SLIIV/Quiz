using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelTaskUI : MonoBehaviour, ILevelTaskUI
    {
        [SerializeField] private Text _taskName;
        public void ChangeTask(ITaskGenerator taskGenerator)
        {
            _taskName.text = taskGenerator.GetCurrentTask().ObjectNameToFind;
        }
    }
}
