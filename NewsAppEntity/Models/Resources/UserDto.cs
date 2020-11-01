using System.ComponentModel.DataAnnotations;

namespace NewsAppEntity.Models.Resources
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
