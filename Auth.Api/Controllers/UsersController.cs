using Auth.Api.Data;
using Auth.Api.Entities;
using Auth.Api.Filters;
using Auth.Api.Helper;
using Auth.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(createUserModel);
            }

            var userEntity = new UserEntity
            {
                Name = createUserModel.Name,
                Phone = createUserModel.Phone,
                Key = GuidGenerator.GenerateNewGuidString,
            };

            _context.Users.Add(userEntity);
            _context.SaveChanges();

            return Ok(userEntity);
        }

        [AuthFilter]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.Include(u => u.Problems).ToList();

            return Ok(users);
        }
    }
}
