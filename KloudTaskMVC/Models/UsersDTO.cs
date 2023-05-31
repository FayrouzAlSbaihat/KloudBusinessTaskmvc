using Microsoft.Build.Framework;

namespace KloudTaskMVC.Models
{
    public class UsersDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
