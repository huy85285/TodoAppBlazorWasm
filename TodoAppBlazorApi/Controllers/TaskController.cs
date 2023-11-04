using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TodoAppBlazor.Api.Respositories;
using TodoList.Models;
using TodoList.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace TodoAppBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        public ITaskRespository _TaskRespository { get; }
        public TaskController(ITaskRespository taskRespository)
        {
            _TaskRespository = taskRespository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _TaskRespository.GetTaskList();
            var ltstaskDtos = tasks.Select(x => new TaskDto { Id = x.Id,
                AssigneeId = x.AssigneeId,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + " " + x.Assignee.LastName:"N/A" });
            return Ok(ltstaskDtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tasks = await _TaskRespository.Create(new Entities.Task() 
            {
                Id=request.Id,
                Priority=request.Priority,
                Name=request.Name,
                Status= Status.Open
            });
            return CreatedAtAction(nameof(GetById), new TaskDto
            {
                Id = tasks.Id,
                Priority = tasks.Priority,
                Name = tasks.Name,
                Status = Status.Open
            });
        }
        [HttpPost("Id")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var tasks = await _TaskRespository.GetById(Id);
            if (tasks==null)
            {
                return NotFound($"{Id} not found ");
            }
            return Ok(new TaskDto
            {
                Id=tasks.Id,
                Priority=tasks.Priority,
                Name=tasks.Name,
                Status= Status.Open
            });
        }
        [HttpPut("Id")]
        public async Task<IActionResult> Update(Guid Id,Entities.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var taskFromDb = _TaskRespository.GetById(Id);
            if (taskFromDb == null)
            {
                return NotFound($"{Id} not found ");

            }
            var tasks = await _TaskRespository.Update(task);
            return Ok(new TaskDto
            {
                Id = tasks.Id,
                Priority = tasks.Priority,
                Name = tasks.Name,
                Status = Status.Open
            });
        }

    }
}
