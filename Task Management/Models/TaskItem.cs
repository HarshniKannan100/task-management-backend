using System.ComponentModel.DataAnnotations;
namespace Task_Management.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Deadline { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
