using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Interfaces
{
    public interface ITaskData
    {

        public void AddTask(ToDoApi.Models.Task task);

        public List<ToDoApi.Models.Task> GetTasksByUserId(int userId);

        public Task<ToDoApi.Models.Task> UpdateTask(ToDoApi.Models.Task task);

        public Task<ToDoApi.Models.Task> DeleteTask(int id);
    }
}
