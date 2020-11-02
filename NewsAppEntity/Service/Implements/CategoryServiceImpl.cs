using AutoMapper;
using NewsAppEntity.Models;
using NewsAppEntity.Models.Resources;
using NewsAppEntity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsAppEntity.Service.Implements
{
    public class CategoryServiceImpl : ICategoryService
    {
        private MyDbContext _dbContext;
        private IMapper _mapper;
        public CategoryServiceImpl(MyDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = GetById(id);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll() //for Admin
        {
            return _dbContext.Categories.Select(x=>x);
        }

        public Category GetByCategoryName(string name)
        {
            Category category = _dbContext.Categories.Where(s => s.Name == name).First();
            if (category != null)
                return category;
            else
                throw new Exception();//Not found
        }

        public Category GetById(int id)
        {
            Category category = _dbContext.Categories.Where(s => s.Id == id).First();
            if (category != null)
                return category;
            else
                throw new Exception();//Not found
        }

        public void Update(int id, CategoryDto categoryDto)
        {
            Category _category = _dbContext.Categories.Where(s => s.Id == id).First();
            if (_category != null)
            {
                _category.Name = categoryDto.Name;
                _category.Priority = categoryDto.Priority;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception();//Not found
            }
        }

        public void UpdateStatus(int id,bool bit)
        {
            Category _category = _dbContext.Categories.Where(s => s.Id == id).First();
            if (_category != null)
            {
                _category.IsActive = bit;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception();//Not found
            }
        }
        public IEnumerable<Category> GetAllActives()//for users
        {
            return _dbContext.Categories.Where(s => s.IsActive==true).Select(x => x);
        }

        public void UpdateIsActive(int id, int bit)
        {
            Category category = GetById(id);
            if (bit == 1)
                category.IsActive = true;
            else if (bit == 0)
                category.IsActive = false;
            _dbContext.SaveChanges();
        }
    }
}
