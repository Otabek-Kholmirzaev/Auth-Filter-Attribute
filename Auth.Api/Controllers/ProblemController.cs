using Auth.Api.Data;
using Auth.Api.Entities;
using Auth.Api.Filters;
using Auth.Api.Models;
using Auth.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthFilter]
    public class ProblemController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProblemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("user-id/{userId}")]
        public IActionResult AddProblem(int userId, CreateProblemModel createProblemModel)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            
            if (user == null)
            {
                return BadRequest();
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(createProblemModel);
            }

            var problemEntity = new ProblemEntity
            {
                Number = createProblemModel.Number,
                Digit = createProblemModel.Digit,
                Answer = SolutionService.GetAnswer(createProblemModel),
                UserEntityId = user.Id
            };
            _context.Problems.Add(problemEntity);
            _context.SaveChanges();

            return Ok(problemEntity);
        }

        [HttpGet]
        public IActionResult GetProblems()
        {
            var problems = _context.Problems.ToList();

            return Ok(problems);
        }
    }
}
