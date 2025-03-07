using Doctor_Data.DB_Context;
using Doctor_Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_DOCTOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIActionResultController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserIActionResultController(ApplicationDbContext context)
        {
            _context=context;
        }

        /// <summary>
        /// Devuelve la lista de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users =await  _context.Users.ToListAsync();
            return Ok(users);
        }

        /// <summary>
        /// Devuelve un usuario por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }
    }
}
