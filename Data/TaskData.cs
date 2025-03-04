using ToDoApi.Interfaces;

namespace ToDoApi.Data
{
    public class TaskData : ITaskData
    {
        public readonly ToDoDbContext _context;

        public TaskData(ToDoDbContext context)
        {
            _context = context;
        }

        public void AddTask(ToDoApi.Models.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public List<ToDoApi.Models.Task> GetTasksByUserId(int userId)
        {
            return _context.Tasks.Where(t => t.UserId == userId).ToList();
        }

        public Task<ToDoApi.Models.Task> GetTaskById(int id) 
        {
            var task = _context.Tasks.Find(id);
            return task == null ? throw new ArgumentException("Task not found") : Task.FromResult(task);
        }

        public Task<ToDoApi.Models.Task> UpdateTask(ToDoApi.Models.Task task)
        {
            var existingTask = _context.Tasks.Find(task.Id) ?? throw new ArgumentException("Task not found");

            existingTask.Status = string.IsNullOrEmpty(task.Status) ? existingTask.Status : task.Status;
            existingTask.Title = string.IsNullOrEmpty(task.Title) ? existingTask.Title : task.Title;
            existingTask.Description = string.IsNullOrEmpty(task.Description) ? existingTask.Description : task.Description;
            existingTask.UpdatedAt = task.UpdatedAt;

            _context.SaveChanges();
            return System.Threading.Tasks.Task.FromResult(task);
        }

        public Task<ToDoApi.Models.Task> DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                throw new ArgumentException("Task not found");
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return System.Threading.Tasks.Task.FromResult(task);
        }

    }
}
