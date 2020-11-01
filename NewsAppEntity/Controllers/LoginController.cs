using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NewsAppEntity.Models.Resources;
using NewsAppEntity.Service;

namespace NewsAppEntity.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("signIn")]
        public IActionResult SignIn(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                HttpContext.SignInAsync("myCookie", _userService.Login(userDto));
                return RedirectToAction("Index", "Admin");
            }
            TempData["error"] = "Input is not valid";
            return View("Index");
        }
    }
}
