using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DataContext DataContext { get; }
        public UserController(DataContext dataContext)
        {
            DataContext = dataContext;

        }
        [HttpGet]
       
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await DataContext.Users.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> Get(int id)
        {
            var users = await DataContext.Users
                .Where(c => c.Id == id)
                .ToListAsync();
            return users;


        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> Create(CreateUserDto request)
        {
            var role = await DataContext.Roles.FindAsync(request.RoleId);
            if(role == null)
                return NotFound();
            var newUser = new User
            {
                Role = role,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserEmail = request.UserEmail,
                UserPhone = request.UserPhone

            };
            DataContext.Users.Add(newUser);
            await DataContext.SaveChangesAsync();
            return await Get(newUser.RoleId);

    }
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(CreateUserDto request)
        {
            var dbUser = await DataContext.Users.FindAsync(request.Id);
            if (dbUser == null)
                return BadRequest("user not found");
            dbUser.FirstName = request.FirstName;
            dbUser.LastName = request.LastName;
            dbUser.UserEmail = request.UserEmail;
            dbUser.UserPhone = request.UserPhone;
            dbUser.RoleId = request.RoleId;


            await DataContext.SaveChangesAsync();

            return Ok(await DataContext.Users.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> RemoveUser(int id)
        {
            var dbUser = await DataContext.Users.FindAsync(id);
            if (dbUser == null)
                return BadRequest("user not found");
            DataContext.Users.Remove(dbUser);
            await DataContext.SaveChangesAsync();
            return Ok(await DataContext.Users.ToListAsync());
        }
    }
    
}

