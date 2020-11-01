using System.ComponentModel.DataAnnotations;

namespace NewsAppEntity.Models.Resources
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Priority { get; set; }
    }
}
