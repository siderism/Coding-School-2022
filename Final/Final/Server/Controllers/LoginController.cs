
using Final.EF.Context;
using Final.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController
    {
        private FinalContext _context;
        public LoginController(FinalContext context)
        {
            _context = context;
        }

        [HttpGet("{username}/{password}")]
        public async Task<LoginViewModel> Get(int id, string username, string password)
        {
            LoginViewModel user = new();
            var found = _context.Users.FirstOrDefault(user => user.Username == username && user.Password == password);
            if(found == null)
                return user;
            user.Username = found.Username;
            user.Role = found.Role;
            user.IsAuth = true;
            return user;
        }
    }
}
