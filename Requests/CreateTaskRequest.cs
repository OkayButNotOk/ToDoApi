using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Requests
{
    public class CreateTaskRequest
    {
        [Required]
        [MinLength(3,ErrorMessage = "Title should be at least 3 characters long.")]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
