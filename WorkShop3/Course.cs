using System.ComponentModel.DataAnnotations;

namespace WorkShop3
{
    public class Course
    {
        [Key]  // defining primary key
        public int CourseId { get; set; }
        [Required]
        [StringLength(50)]

        public string Name { get; set; }

        public int DurationYears { get; set; }

    }
}
