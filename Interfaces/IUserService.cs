using System.Drawing;
using ToDoApi.DTOs;
using ToDoApi.Models;
using ToDoApi.Responses;

namespace ToDoApi.Interfaces
{
    public interface IUserService
    {
        ServiceResponse RegisterUser(UserDto userDto);
        User GetUser(string username);
    }
}
