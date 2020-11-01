using NewsAppEntity.Models;
using NewsAppEntity.Models.Resources;
using System.Collections.Generic;

namespace NewsAppEntity.Service
{
    public interface INewsService
    {
        public void Create(NewsDto news);
        public News GetById(int id);
        public void Update(int id, NewsUpdateDto newsDto);
        public IEnumerable<News> GetAll();
        public void UpdateIsActive(int id,int bit);
        public void Delete(int id);
        public IEnumerable<News> GetAllActives();
    }
}
