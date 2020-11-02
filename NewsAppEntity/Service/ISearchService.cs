using NewsAppEntity.Models;
using System;
using System.Collections.Generic;

namespace NewsAppEntity.Service
{
    public interface ISearchService
    {
        public IEnumerable<News> SearchByTitleAndDate(string title, DateTime dateTime);
    }
}
