using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop3
{
    public class Student
    {
        [Key]  // defining primary key
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public long PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}
