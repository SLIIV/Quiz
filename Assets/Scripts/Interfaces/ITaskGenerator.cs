using Level;

public interface ITaskGenerator
{
    public void GenerateTask(ICellsGeneratable cellsGenerator);
    public Task GetCurrentTask();
}
