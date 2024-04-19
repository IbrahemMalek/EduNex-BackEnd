using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexDB.Entites
{
    public class StudentsAnswersSubmissions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public virtual Exam? Exam { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }

        [ForeignKey("Answer")]
        public int? AnswerId { get; set; }
        public virtual Answer? Answer { get; set; }

    }
}
