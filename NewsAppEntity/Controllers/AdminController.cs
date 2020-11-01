using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsAppEntity.Models.Resources;
using NewsAppEntity.Service;
using NewsAppEntity.Service.Implements;

namespace NewsAppEntity.Controllers
{
    [Route("admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private INewsService _newsService;
        private ICategoryService _categoryService;
        public AdminController(INewsService newsService , ICategoryService categoryService)
        {
            _newsService = newsService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("createNews")]
        public IActionResult CreateNews()
        {
            return View(_categoryService.GetAllActives());
        }
        [HttpPost("createNews")]
        [Consumes("multipart/form-data")]
        public IActionResult CreateNews(NewsDto newsDto)
        {
            if (ModelState.IsValid)
            {
                _newsService.Create(newsDto);
                return RedirectToAction("AllNews");
            }
                TempData["error"] = "All input must be filled";
                return View("CreateNews", _categoryService.GetAllActives());
        }
        [HttpGet("updateNews")]
        public IActionResult UpdateNews(int id)
        {
            return View(_newsService.GetById(id));
        }
        [HttpPost("updateNews")]
        public IActionResult UpdateNews(int id,NewsUpdateDto newsDto)
        {
            if (ModelState.IsValid)
            {
                _newsService.Update(id, newsDto);
                return RedirectToAction("AllNews");
            }
                TempData["error"] = "All input must be filled";
                return View("updateNews", _newsService.GetById(id));
        }
       [HttpGet("allNews")]
       public IActionResult AllNews()
        {
            return View(_newsService.GetAll());
        }
        [HttpGet("trigNewsIsActive")]
        public IActionResult TrigNewsIsActive(int id,int bit)
        {
            _newsService.UpdateIsActive(id, bit);
            return RedirectToAction("AllNews");
        }
        [HttpGet("deleteNews")]
        public IActionResult DeleteNews(int id)
        {
            _newsService.Delete(id);
            return RedirectToAction("AllNews");
        }
        [HttpGet("AllCategories")]
        public IActionResult AllCategories()
        {
            return View(_categoryService.GetAll());
        }
        [HttpGet("UpdateCategory")]
        public IActionResult UpdateCategory(int id)
        {
            return View(_categoryService.GetById(id));
        }
        [HttpPost("UpdateCategory")]
        public IActionResult UpdateCategory(int id,CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(id, categoryDto);
                return RedirectToAction("AllCategories");
            }
            TempData["error"] = "All input must be filled";
            return View("updateCategory", _categoryService.GetById(id));
        }
        [HttpGet("trigCategoryIsActive")]
        public IActionResult TrigCategoryIsActive(int id, int bit)
        {
            _categoryService.UpdateIsActive(id, bit);
            return RedirectToAction("AllCategories");
        }
        [HttpGet("createCategory")]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost("createCategory")]
        public IActionResult CreteCategory(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(categoryDto);
                return RedirectToAction("AllCategories");
            }
            TempData["error"] = "All input must be filled";
            return View("createCategory");
        }
    }
}
