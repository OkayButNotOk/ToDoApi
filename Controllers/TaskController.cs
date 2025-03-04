using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoApi.Interfaces;
using ToDoApi.Requests;

namespace ToDoApi.Controllers
{
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly HttpContextAccessor _contextAccessor;
        public TaskController(ITaskService taskService, HttpContextAccessor contextAccessor)
        {
            _taskService = taskService;
            _contextAccessor = contextAccessor;
        }
        private int GetUserId() 
        {
            return int.Parse(_contextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value?? "-1");
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] CreateTaskRequest createTaskRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();
            _taskService.AddTask(userId, createTaskRequest);
            return Ok();
        }

        [HttpGet("tasks")]
        public IActionResult GetTasks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();
            var tasks = _taskService.GetTasksByUserId(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();
            var tasks = _taskService.GetTask(id,userId);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] UpdateTaskRequest updateTaskRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();

            var updatedTask = _taskService.UpdateTask(id,userId,updateTaskRequest);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedTask = _taskService.DeleteTask(id);
            return Ok(deletedTask);
        }
    }
}
