using NewsAppEntity.Models;

namespace NewsAppEntity.Service
{
    public interface IPhotoService
    {
        public int Create(Photo photo);
        public Photo GetPhotoById(int id);
    }
}
