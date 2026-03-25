using Microsoft.AspNetCore.Mvc;

namespace WorkShop3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetAllCourse()
        {
            return Ok(_context.Courses.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetACourse(long id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
            {
                return NotFound($"Course with id {id} not found");
            }

            return Ok(course);
        }

        [HttpPost("")]
        public IActionResult SaveCourse(Course c)
        {
            var check = _context.Courses.Find(c.CourseId);
            if (check != null)
            {
                return ValidationProblem($"Course with id {c.CourseId} already exists.");
            }
            _context.Courses.Add(c);
            _context.SaveChanges();
            return Ok($"Course {c.Name} saved successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(long id, Course c)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound($"Course with id {id} not found.");
            }
            course.Name = c.Name;
            course.DurationYears = c.DurationYears;
            _context.SaveChanges();
            return Ok($"Course {course.Name} updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(long id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
            {
                return NotFound($"Course with id {id} not found");
            }

            var name = course.Name;

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return Ok($"Deleted course {name} with id {id}");
        }

        [HttpPost("bulk")]
        public IActionResult SaveCourses(List<Course> s)
        {
            _context.Courses.AddRange(s);
            _context.SaveChanges();
            return Ok("Saved Courses in bulk");
        }

        [HttpGet("count")]
        public IActionResult GetCourseCount()
        {
            var count = _context.Courses.Count();
            return Ok($"Total number Courses are: {count}");
        }
    }
}
