using ToDoApi.Interfaces;
using ToDoApi.Models;
using ToDoApi.Responses;

namespace ToDoApi.Data
{
    public class UserData : IUserData
    {
        public readonly ToDoDbContext _context;
        public UserData(ToDoDbContext context)
        {
            _context = context;
        }

        public ServiceResponse RegisterUser(User user)
        {
            if(_context.Users.Any(x => x.Username == user.Username))
            {
               return new ServiceResponse { IsSuccess = false, Message = "Username already exists" };
            }
               
            _context.Users.Add(user);
            _context.SaveChanges();

            return new ServiceResponse { IsSuccess = true, Message = "User registered successfully" };
        }

        public Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return System.Threading.Tasks.Task.FromResult(user);
        }

        public Task<User> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return System.Threading.Tasks.Task.FromResult(user);
        }

        public Task<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return System.Threading.Tasks.Task.FromResult(user);
        }
    }
}
