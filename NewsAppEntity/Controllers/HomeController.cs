using Microsoft.AspNetCore.Mvc;
using NewsAppEntity.Models.ViewModels;
using NewsAppEntity.Service;
using NewsAppEntity.Service.Implements;
using System;

namespace NewsAppEntity.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _categoryService;
        private INewsService _newsService;
        private ISearchService _searchService;

        public HomeController(ICategoryService categoryService,INewsService newsService,ISearchService searchService)
        {
            _categoryService = categoryService;
            _newsService = newsService;
            _searchService = searchService;
        }
        public IActionResult Index()
        {
            HomeIndex viewModel = new HomeIndex();
            viewModel.News = _newsService.GetAllActives();
            viewModel.Categories = _categoryService.GetAllActives();
            return View(viewModel);
        }
        [HttpGet("categorySearch")]
       public IActionResult SearchByCategory(string category)
        {
            return View("Results",_newsService.GetAllActivesByCategoryName(category)); 
        }
        [HttpGet("search")]
        public IActionResult Search(DateTime dateTime , string title)
        {
            return View("SearchResult",_searchService.SearchByTitleAndDate(title,dateTime));
        }
        [HttpGet("apply")]
        public IActionResult Apply()
        {
            return View();
        }
    }
}
