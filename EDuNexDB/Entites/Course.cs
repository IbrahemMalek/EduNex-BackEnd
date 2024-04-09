using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDuNexDB.Entites
{
    public enum CourseType
    {
        [Display(Name = "Literature")]
        Literature,
        [Display(Name = "Scientific")]
        Scientific,
        [Display(Name = "Revision")]
        Revision
    }
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public CourseType CourseType { get; set; }

        [Required]
        public int NumberOfLectures { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
