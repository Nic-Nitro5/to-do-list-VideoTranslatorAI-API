using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_list_api.Data;
using todo_list_api.Models.DTOs.User;

namespace todo_list_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TodoDBContext dbContext;
        public AuthController(TodoDBContext dBContext)
        {
            dbContext= dBContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequest loginUserRequest)
        {
            var existingUser = await dbContext.users.FirstOrDefaultAsync(u => u.email == loginUserRequest.email && u.password == loginUserRequest.password);

            if (existingUser != null)
            {
                return Ok(existingUser);
            }

            return Ok(false);
        }
    }
}
