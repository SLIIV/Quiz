using UnityEngine;

public interface ILevelScaleble
{
    public void ScaleLevel(ScriptableObjects.LevelType level);
    public Transform GetTransform();
}
