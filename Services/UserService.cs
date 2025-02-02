using ToDoApi.Interfaces;
using ToDoApi.Models;
using ToDoApi.Responses;

namespace ToDoApi.Services
{
    public class UserService : IUserService
    {
        public readonly IUserData _userData;
        public UserService(IUserData userData)
        {
            _userData = userData;
        }

        public ServiceResponse RegisterUser(User user)
        {
            CheckIfUsernameValid(user.Username);
            CheckIfPasswordValid(user.PasswordSalt);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordSalt);
            
            return _userData.RegisterUser(user);
        }

        private static void CheckIfPasswordValid(string passwordSalt)
        {
            switch (passwordSalt) 
            {
                case null:
                    throw new ArgumentNullException("Password cannot be null");
                case "":
                    throw new ArgumentException("Password cannot be empty");
                case string s when s.Length < 8:
                    throw new ArgumentException("Password must be at least 8 characters long");
                case string s when s.Length > 20:
                    throw new ArgumentException("Password must be at most 20 characters long");
                case string s when !s.Any(char.IsDigit):
                    throw new ArgumentException("Password must contain at least one digit");
                case string s when !s.Any(char.IsUpper):
                    throw new ArgumentException("Password must contain at least one uppercase letter");
                case string s when !s.Any(char.IsLower):
                    throw new ArgumentException("Password must contain at least one lowercase letter");
                case string s when !s.Any(char.IsSymbol):
                    throw new ArgumentException("Password must contain at least one special character");
                default:
                    break;
            }
        }

        private static void CheckIfUsernameValid(string username)
        {
            switch (username)
            {
                case null:
                    throw new ArgumentNullException("Username cannot be null");
                case "":
                    throw new ArgumentException("Username cannot be empty");
                case string s when s.Length < 3:
                    throw new ArgumentException("Username must be at least 3 characters long");
                case string s when s.Length > 20:
                    throw new ArgumentException("Username must be at most 20 characters long");
                default:
                    break;
                }
            }
    }
}
