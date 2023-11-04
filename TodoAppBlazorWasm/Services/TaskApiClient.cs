using TodoList.Models;
namespace TodoAppBlazorWasm.Services;
public class TaskApiClient : ITaskApiClient
{
    public HttpClient _HttpClient;

    public TaskApiClient(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<List<TaskDto>> GetTaskList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<TaskDto>>("Api/tasks");
        return result;
    }
}
