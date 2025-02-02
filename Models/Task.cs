using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength]
        public string Title { get; set; }
        [Required]
        [MaxLength]
        public string Description { get; set; }
        [Required]
        [StringLength(15)]
        public string Status { get; set; } // "todo", "in-progress", "done"
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; } = new User();
    }
}
