using ToDoApi.Models;
using ToDoApi.Responses;

namespace ToDoApi.Interfaces
{
    public interface IUserService
    {
        ServiceResponse RegisterUser(User user);
    }
}
