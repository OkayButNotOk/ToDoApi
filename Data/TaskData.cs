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

        public Task<ToDoApi.Models.Task> UpdateTask(ToDoApi.Models.Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return System.Threading.Tasks.Task.FromResult(task);
        }

        public Task<ToDoApi.Models.Task> DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return System.Threading.Tasks.Task.FromResult(task);
        }

    }
}
