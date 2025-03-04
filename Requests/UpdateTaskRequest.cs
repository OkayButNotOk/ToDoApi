using System.ComponentModel.DataAnnotations;
using ToDoApi.Models;

namespace ToDoApi.Requests
{
    public class UpdateTaskRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Status cannot be empty")]
        public Enums.TaskStatus Status { get; set; }
    }
}
