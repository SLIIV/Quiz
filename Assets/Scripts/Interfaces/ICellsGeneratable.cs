using System.Collections.Generic;
using UnityEngine;

public interface ICellsGeneratable
{
    public void GenerateLevelPull(ScriptableObjects.LevelType level);
    public void ShowGeneratedPull(ILevelScaleble gameZone);
    public void DeleteGeneratedPull(ILevelScaleble gameZone);
    public List<ScriptableObjects.ObjectInCell> GeneratedPull();
    public List<GameObject> CreatedCells();
}
