using NewsAppEntity.Models;
using NewsAppEntity.Models.Resources;
using System.Security.Claims;

namespace NewsAppEntity.Service
{
    public interface IUserService
    {
        public ClaimsPrincipal Login(UserDto userDto);
    }
}
