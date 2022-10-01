using System;
using System.ComponentModel.DataAnnotations;

namespace Sinara_task.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public string ActiveDirectory { get; set; }
    }
}
