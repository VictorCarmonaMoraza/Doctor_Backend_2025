using API_DOCTOR.Controllers.ControllerBase;
using Doctor_Data.DB_Context;
using Doctor_Model.DTOs;
using Doctor_Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API_DOCTOR.Controllers
{
    public class UserIActionResultController : BaseApiController
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

        /// <summary>
        /// Registra un usuario en la base de datos
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            //Validamos si el usuario existe en la base de datos
            if (await UserExists(registerDto.UserName))
            {
                return BadRequest("Username is taken");
            }
            //El usign se utiliza para que libere memoria al final
            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        /// <summary>
        /// Valida si un usuario existe en la base de datos
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
