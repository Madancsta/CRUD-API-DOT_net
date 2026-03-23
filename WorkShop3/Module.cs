using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop3
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        [Required]
        [StringLength(50)]

        public string Title { get; set; }

        public string Credits{ get; set; }

        [ForeignKey(nameof(Course))]  // defining foreign key
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
