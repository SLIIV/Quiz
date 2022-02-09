using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class GamePanel : MonoBehaviour, ILevelScaleble
    {
        public void ScaleLevel(ScriptableObjects.LevelType level)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            float weight = level.Columns * level.CellSize;
            float height = level.Rows * level.CellSize;
            rectTransform.sizeDelta = new Vector2(weight, height);
        }
		
        public Transform GetTransform()
        {
            return transform;
        }
    }
}
