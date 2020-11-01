using System;
using System.ComponentModel.DataAnnotations;

namespace NewsAppEntity.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileTarget { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
