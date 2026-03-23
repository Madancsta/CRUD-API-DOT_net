using Microsoft.AspNetCore.Mvc;
using Workshop2;
using WorkShop3;

namespace Workshop2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllStudent()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpPost("save")]
        public IActionResult SaveStudent(Student s)
        {
            _context.Students.Add(s);
            return Ok(_context);
        }

        [HttpPatch("update")]
        public IActionResult UpdateStudent(Student s)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == s.Id);
            student.FirstName = s.FirstName;
            student.LastName = s.LastName;
            return Ok(s);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteStudent(int id)
        {
            _context.Students.Remove(s => s.StudentId == id);
            return Ok($"Deleted student with id{id}");
        }
    }
}
