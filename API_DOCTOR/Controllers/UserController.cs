using Doctor_Data.DB_Context;
using Doctor_Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_DOCTOR.Controllers
{
    [Route("api/[controller]")] // api/user
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context=context;
        }

        /// <summary>
        /// Devuelve la lista de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<User> GetUsers2()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        /// <summary>
        /// Devuelve un usuario por su id
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<User> GetUser2(int id)
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
