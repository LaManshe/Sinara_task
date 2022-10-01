using System.ComponentModel.DataAnnotations;

namespace Sinara_task.Models
{
    public class Post
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool IsVisible { get; set; }
    }
}
