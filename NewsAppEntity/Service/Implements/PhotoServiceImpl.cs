using NewsAppEntity.Models;
using NewsAppEntity.Repository;
using System;
using System.Linq;

namespace NewsAppEntity.Service.Implements
{
    public class PhotoServiceImpl : IPhotoService
    {
        private MyDbContext _dbContext;
        public PhotoServiceImpl(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Photo photo)
        {
            _dbContext.Photos.Add(photo);
            _dbContext.SaveChanges();
            int photoId = _dbContext.Photos.Max(u => u.Id);
            return photoId;
        }

        public Photo GetPhotoById(int id)
        {
            Photo photo = _dbContext.Photos.Where(s => s.Id == id).First();
            if (photo != null)
            {
                return photo;
            }
            throw new Exception();//not found;
        }
    }
}
