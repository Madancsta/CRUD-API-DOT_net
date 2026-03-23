using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkShop3
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey(nameof(Student))]
        public long StudentId { get; set; }
        public virtual Student Student {  get; set; }

        [ForeignKey(nameof(Course))]  // defining foreign key
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
