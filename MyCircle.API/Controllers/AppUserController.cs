using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCircle.API.Data;
using MyCircle.API.Entities;

namespace MyCircle.API.Controllers
{
    [Authorize]
    public class AppUserController : BaseApiController
    {
        private readonly DataContext dataContext;
    
        public AppUserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            var users = dataContext.Users;
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = dataContext.Users.Find(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(AppUser user)
        {
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpdateUser(AppUser user)
        {
            dataContext.Users.Update(user);
            dataContext.SaveChanges();
            return Ok(user);
        }
    }
}
