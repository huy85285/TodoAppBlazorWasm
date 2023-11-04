using TodoList.Models;
namespace TodoAppBlazorWasm.Services;
public interface ITaskApiClient
{
    public Task<List<TaskDto>> GetTaskList();
}
