using Doctor_Data.DB_Context;
using Doctor_Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        /// <summary>
        /// Devuelve un usuario por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }
    }
}
