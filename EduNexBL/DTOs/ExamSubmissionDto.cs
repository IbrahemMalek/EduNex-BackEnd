using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexBL.DTOs
{
    public class ExamSubmissionDto
    {
        [Required]
        public int StudentId { get; set; }
  
        [Required]
        public List<SubmittedQuestionDto> Answers { get; set; } = null!; 
    }
}
