using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using NewsAppEntity.Models;
using NewsAppEntity.Models.Resources;
using NewsAppEntity.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NewsAppEntity.Service.Implements
{
    public class NewsServiceImpl : INewsService
    {
        private MyDbContext _dbContext;
        private IMapper _mapper;
        private IWebHostEnvironment _enviroment;
        private IPhotoService _photoService;
        private ICategoryService _categoryService;
        public NewsServiceImpl(MyDbContext dbContext,IMapper mapper,IWebHostEnvironment enviroment
            ,IPhotoService photoService, ICategoryService categoryService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _enviroment = enviroment;
            _photoService = photoService;
            _categoryService = categoryService;
        }
        public void Create(NewsDto newsDto)
        {
            Photo photo = new Photo();
            Category category = _categoryService.GetByCategoryName(newsDto.CategoryName);
            photo.FileName = newsDto.PhotoFile.FileName;
            string dirPath = _enviroment.WebRootPath + "/images/" + photo.FileName;
            dirPath = dirPath.Replace("/", @"\");
            using (FileStream fs = File.Create(dirPath))
            {
                newsDto.PhotoFile.CopyTo(fs);
                fs.Flush();
            }
            photo.FileTarget = dirPath;
           int photoId = _photoService.Create(photo);
            News news = _mapper.Map<News>(newsDto);
            news.PhotoId = photoId;
            news.CategoryId = category.Id;
            _dbContext.News.Add(news);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            News news = GetById(id);
            Photo photo = _photoService.GetPhotoById(news.PhotoId);
            if (File.Exists(photo.FileTarget))
                File.Delete(photo.FileTarget);
            _dbContext.Photos.Remove(photo);
            _dbContext.News.Remove(news);
            _dbContext.SaveChanges();
        }

        public IEnumerable<News> GetAll() // for admin
        {
            var query = _dbContext.News.Join(_dbContext.Photos,
                  news => news.PhotoId,
                  photo => photo.Id,
                  (news, photo) => new
                  {
                      news2 = news,
                      photo2 = photo
                  }).ToList();
            List<News> news = new List<News>();
            foreach (var data in query)
            {
                News _news = new News();
                _news = data.news2;
                _news.Photo = data.photo2;
                news.Add(_news);
            }
            return news;
        }

        public IEnumerable<News> GetAllActives() // for user
        {
            var query = _dbContext.News.Where(s => s.IsActive == true && s.PublishedDate <= DateTime.Now).
                  Join(_dbContext.Photos,
                  news => news.PhotoId,
                  photo => photo.Id,
                  (news, photo) => new
                  {
                      news2 = news,
                      photo2 = photo
                  }).ToList();
            List<News> news = new List<News>();
            foreach (var data in query)
            {
                News _news = new News();
                _news = data.news2;
                _news.Photo = data.photo2;
                news.Add(_news);
            }
            return news;
        }

        public News GetById(int id)
        {
            var query = _dbContext.News.Where(s => s.Id == id).Join(_dbContext.Photos,
                  news => news.PhotoId,
                  photo => photo.Id,
                  (news, photo) => new
                  {
                      news2 = news,
                      photo2 = photo
                  }).First();

            if (query.news2 != null)
            {
                News news = query.news2;
                news.Photo = query.photo2;
                return news;
            }
            else
            {
                throw new Exception(); //not found
            }
        }

        public void Update(int id, NewsUpdateDto newsDto)
        {
            News news = GetById(id);
            Category category = _categoryService.GetByCategoryName(newsDto.CategoryName);
            news.HtmlContent = newsDto.HtmlContent;
            news.Title = newsDto.Title;
            news.Subtitle = newsDto.Subtitle;
            news.PublishedDate = newsDto.PublishedDate;
            news.CategoryId = category.Id;
            _dbContext.SaveChanges();
        }

        public void UpdateIsActive(int id,int bit)
        {
            News news = GetById(id);
            if(bit==1)
            news.IsActive = true;
            else if(bit==0)
                news.IsActive = false;
            _dbContext.SaveChanges();
        }
    }
}
