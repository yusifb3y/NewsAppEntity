using System.Collections.Generic;

namespace NewsAppEntity.Models.ViewModels
{
    public class HomeIndex
    {
       public IEnumerable<News> News { get; set; }
       public IEnumerable<Category> Categories { get; set; }
    }
}
