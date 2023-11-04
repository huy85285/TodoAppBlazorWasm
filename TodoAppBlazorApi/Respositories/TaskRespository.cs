using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using TodoAppBlazor.Api.Data;
using TodoAppBlazor.Api.Entities;
using Task = TodoAppBlazor.Api.Entities.Task;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TodoAppBlazor.Api.Respositories
{
    public class TaskRespository : ITaskRespository
    {
        private readonly TodoListDbContext _todoListDbContext;

        public TaskRespository(TodoListDbContext todoListDbContext)
        {
            _todoListDbContext = todoListDbContext;
        }

        public async Task<Task> Create(Task task)
        {
            await _todoListDbContext.AddAsync(task);
            await _todoListDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Delete(Task task)
        {
            _todoListDbContext.Remove(task);
            await _todoListDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _todoListDbContext.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<Entities.Task>> GetTaskList()
        {
            return await _todoListDbContext.Tasks.ToListAsync();
        }

        public async Task<Entities.Task> Update(Entities.Task task)
        {
            _todoListDbContext.Update(task);
            await _todoListDbContext.SaveChangesAsync();
            return task;
        }
    }
}
