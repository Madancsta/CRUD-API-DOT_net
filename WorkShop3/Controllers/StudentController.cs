using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("")]
        public IActionResult GetAllStudent()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAStudent(long id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound($"Student with id {id} not found");
            }

            return Ok(student);
        }

        [HttpPost("")]
        public IActionResult SaveStudent(Student s)
        {
            var check = _context.Students.Find(s.Id);
            if (check != null)
            {
                return ValidationProblem($"Student with id {s.Id} already exists.");
            }
            _context.Students.Add(s);
            _context.SaveChanges();
            return Ok($"Student {s.FirstName} saved successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(long id, Student s)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound($"Student with id {id} not found.");
            }
            student.FirstName = s.FirstName;
            student.LastName = s.LastName;
            student.Email = s.Email;
            student.DateOfBirth = s.DateOfBirth;
            student.PhoneNumber = s.PhoneNumber;
            _context.SaveChanges();
            return Ok($"Student {student.FirstName} updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound($"Student with id {id} not found");
            }

            var name = student.FirstName;

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok($"Deleted student {name} with id {id}");
        }

        [HttpGet("{id}/course")]
        public IActionResult GetStudentCourse(long id)
        {
            var course = _context.Enrollments
                .Where(e => e.StudentId == id)
                .Join(_context.Courses,
                      e => e.CourseId,
                      c => c.CourseId,
                      (e, c) => new
                      {
                          c.CourseId,
                          c.Name,
                          c.DurationYears
                      })
                .ToList();

            if (course == null || course.Count == 0)
            {
                return NotFound($"Student with id {id}, course not found");
            }

            return Ok(course);
        }

        [HttpPost("bulk")]
        public IActionResult SaveStudents(List<Student> s)
        {
            _context.Students.AddRange(s);
            _context.SaveChanges();
            return Ok("Saved students in bulk");
        }

        [HttpGet("count")]
        public IActionResult GetStudentCount()
        {
            var count = _context.Students.Count();
            return Ok($"Total number students are: {count}");
        }

        [HttpGet("with-courses")]
        public IActionResult GetStudentsWithCourses()
        {
            var data = (from s in _context.Students
                        join e in _context.Enrollments on s.Id equals e.StudentId
                        join c in _context.Courses on e.CourseId equals c.CourseId
                        select new
                        {
                            s.Id,
                            s.FirstName,
                            CourseId = c.CourseId,
                            CourseName = c.Name
                        }).ToList();

            return Ok(data);
        }

        [HttpGet("full-details")]
        public IActionResult GetFullDetails()
        {
            var data = ( from s in _context.Students
                         join e in _context.Enrollments on s.Id equals e.StudentId
                         join c in _context.Courses on e.CourseId equals c.CourseId
                         join m in _context.Modules on c.CourseId equals m.CourseId
                         select new
                         {
                             s.Id,
                             s.FirstName,
                             CourseId = c.CourseId,
                             CourseName = c.Name,
                             ModuleId = m.ModuleId,
                             ModuleTitle = m.Title,
                         }).ToList();
            return Ok(data);
        }
    }
}
