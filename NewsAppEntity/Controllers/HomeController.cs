using Microsoft.AspNetCore.Mvc;
using NewsAppEntity.Service.Implements;

namespace NewsAppEntity.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllActives());
        }
       
    }
}
