using TodoAppBlazor.Api.Entities;
using Task = TodoAppBlazor.Api.Entities.Task;

namespace TodoAppBlazor.Api.Respositories
{
    public interface ITaskRespository
    {
         Task<IEnumerable<Task>> GetTaskList();
         Task<Task> Create(Task task);
         Task<Task> Update(Task task);
         Task<Task> Delete(Task task);
         Task<Task> GetById(Guid id);
    }
}
