using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;
using ToDoApi.Responses;

namespace ToDoApi.Interfaces
{
    public interface IUserData
    {
        public ServiceResponse RegisterUser(User user);

        public Task<User> UpdateUser(User user);

        public Task<User> DeleteUser(int id);

        public User GetUser(string username);
    }
}
