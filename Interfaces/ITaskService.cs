using ToDoApi.Data;
using ToDoApi.Requests;

namespace ToDoApi.Interfaces
{
    public interface ITaskService
    {
        void AddTask(int userId, CreateTaskRequest createTaskRequest);
        List<Models.Task> GetTasksByUserId(int userId);
        Task<Models.Task> GetTask(int id, int userId);
        Task<Models.Task> UpdateTask(int id, int userId, UpdateTaskRequest updateTaskRequest);
        Task<Models.Task> DeleteTask(int id);

    }
}
