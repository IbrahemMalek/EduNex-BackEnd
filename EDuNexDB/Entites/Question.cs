using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexDB.Entites
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Marks { get; set; }
    }
}
