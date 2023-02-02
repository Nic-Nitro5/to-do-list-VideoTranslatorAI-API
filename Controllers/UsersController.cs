using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using todo_list_api.Data;
using todo_list_api.Models.DTOs.User;
using todo_list_api.Models.Entities;

namespace todo_list_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly TodoDBContext dbContext;
        public UsersController(TodoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await dbContext.users.Select(u => new
                {
                    id = u.id, 
                    name = u.name, 
                    email = u.email, 
                    isAdmin = u.admin, 
                    createdAt = u.createdAt 
                }
            ).ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await dbContext.users.FirstOrDefaultAsync(u => u.id == id);

            if(user != null){
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {

            var user = new User()
            {
                id = new Guid(),
                name = addUserRequest.name,
                email = addUserRequest.email,
                password = addUserRequest.password,
                admin = addUserRequest.admin,
                createdAt = addUserRequest.createdAt,
            };

            await dbContext.users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.id }, user);
        }

    }
}
