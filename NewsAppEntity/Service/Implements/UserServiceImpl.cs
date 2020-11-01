using NewsAppEntity.Models;
using NewsAppEntity.Models.Resources;
using NewsAppEntity.Repository;
using System.Linq;
using System.Security.Claims;
using System;

namespace NewsAppEntity.Service.Implements
{
    public class UserServiceImpl : IUserService
    {
        private MyDbContext _dbContext;

        public UserServiceImpl(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ClaimsPrincipal Login(UserDto userDto)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            User user = _dbContext.Users.Where(s => s.Password == userDto.Password && s.Email == userDto.Email).First();
            if (user != null)
            {
                identity = new ClaimsIdentity(new[]
                 {
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Surname,user.Surname),
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.Mobil),
                }, "myCookie");
                isAuthenticate = true;
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                return principal;
            }
            throw new Exception(); // not found
        }
    }
}
