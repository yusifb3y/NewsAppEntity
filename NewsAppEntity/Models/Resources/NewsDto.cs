using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace NewsAppEntity.Models.Resources
{
    public class NewsDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subtitle { get; set; }
        [Required]
        public string HtmlContent { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public IFormFile PhotoFile { get; set; }
    }
}
