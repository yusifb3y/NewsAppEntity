using AutoMapper;
using NewsAppEntity.Models;
using NewsAppEntity.Models.Resources;

namespace NewsAppEntity
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<NewsDto, News>();
            CreateMap<News, NewsDto>();
            CreateMap<News, NewsUpdateDto>();
            CreateMap<NewsUpdateDto, News>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
