using NewsAppEntity.Models;
using NewsAppEntity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsAppEntity.Service.Implements
{
    public class SearchServiceImpl : ISearchService
    {
        private MyDbContext _dbContext;

        public SearchServiceImpl(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<News> SearchByTitleAndDate(string title, DateTime dateTime)
        {
            if (title != null && dateTime != default && dateTime!=null)
            {
                return _dbContext.News.Where(s => s.Title.Contains(title) && s.PublishedDate.Date == dateTime.Date
                && s.IsActive == true && s.PublishedDate <= DateTime.Now).Select(x=>x);
            }
            else if(title != null)
            {
                return _dbContext.News.Where(s => s.Title.Contains(title)
                && s.IsActive == true && s.PublishedDate <= DateTime.Now).Select(x => x);
            }
            else if(dateTime != default && dateTime != null)
            {
                return _dbContext.News.Where(s => s.PublishedDate.Date == dateTime.Date
                && s.IsActive == true && s.PublishedDate <= DateTime.Now).Select(x => x);
            }
            else
            {
                return new List<News>();                            
            }
        }
    }
}
