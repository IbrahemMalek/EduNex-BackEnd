using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexDB.Entites
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int NumberOfQuestions { get; set; }

        [Required]
        public string Type { get; set; }

        [ForeignKey("Lecture")]
        public int LectureId { get; set; }
        public Lecture? Lecture { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
