using ToDoApi.Interfaces;
using ToDoApi.Models;
using ToDoApi.Requests;

namespace ToDoApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskData _taskData;

        public TaskService(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public void AddTask(int userId, CreateTaskRequest createTaskRequest)
        {
            if (string.IsNullOrEmpty(createTaskRequest.Title))
            {
                throw new System.ArgumentException("Title is required");
            }
            var task = new Models.Task()
            {
                Title = createTaskRequest.Title,
                Description = createTaskRequest.Description,
                Status = Enums.TaskStatus.NotStarted.ToString(),
                UserId = userId,
                CreatedAt = System.DateTime.Now
            };
            _taskData.AddTask(task);
        }

        public List<Models.Task> GetTasksByUserId(int userId)
        {
            return _taskData.GetTasksByUserId(userId);
        }

        public Task<Models.Task> GetTask(int id, int userId)
        {
            var task = _taskData.GetTaskById(id);
            if (task.Result == null || task.Result.UserId != userId)
            {
                throw new System.ArgumentException("Task not found");
            }
            return task;
        }

        public Task<Models.Task> UpdateTask(int id, int userId, UpdateTaskRequest updateTaskRequest)
        {
            var task = new Models.Task()
            {
                Id = id,
                Title = updateTaskRequest.Title,
                Description = updateTaskRequest.Description,
                Status = updateTaskRequest.Status.ToString(),
                UserId = userId,
                UpdatedAt = System.DateTime.Now
            };

            return _taskData.UpdateTask(task);
        }

        public Task<Models.Task> DeleteTask(int id)
        {
            return _taskData.DeleteTask(id);
        }

    }
}
