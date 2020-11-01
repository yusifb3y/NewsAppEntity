using NewsAppEntity.Models;
using NewsAppEntity.Models.Resources;
using System.Collections.Generic;

namespace NewsAppEntity.Service.Implements
{
    public interface ICategoryService
    {
        public Category GetById(int id);
        public IEnumerable<Category> GetAll();
        public void Create(CategoryDto categoryDto);
        public void Delete(int id);
        public void Update(int id, CategoryDto categoryDto);
        public void UpdateStatus(int id ,bool bit);
        public Category GetByCategoryName(string name);
        public IEnumerable<Category> GetAllActives();
        public void UpdateIsActive(int id, int bit);
    }
}
