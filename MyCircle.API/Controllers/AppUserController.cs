using Microsoft.AspNetCore.Mvc;
using MyCircle.API.Data;

namespace MyCircle.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppUserController : Controller
    {
        private readonly DataContext dataContext;
        
   

        public AppUserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
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
