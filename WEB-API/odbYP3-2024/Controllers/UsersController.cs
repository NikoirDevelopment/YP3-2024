using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using odbYP3_2024.Data;

namespace odbYP3_2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly OdbYp32024Context _context;

        public UsersController(OdbYp32024Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Загрузка всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Post)
                .Select(u => new
                {
                    u.Name,
                    u.Surname,
                    u.Middlename,
                    u.Email,
                    u.Phone,
                    Position = u.Post.Title
                })
                .ToListAsync();

            return Ok(users);
        }
    }
}
