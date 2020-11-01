using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsAppEntity.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string HtmlContent { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsDelete { get; set; } = false;
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
