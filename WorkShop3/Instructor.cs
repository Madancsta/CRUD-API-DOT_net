using System.ComponentModel.DataAnnotations;

namespace WorkShop3
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public string HireDate { get; set; }

    }
}
