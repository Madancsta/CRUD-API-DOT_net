using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop3
{
    public class ModuleInstructor
    {
        [Key]
        public int ModuleInstructorId { get; set; }
        [ForeignKey(nameof(Module))]
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InstrudtorId { get; set; }
        public virtual Instructor Instructor { get; set; }

    }
}
