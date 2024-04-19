using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EduNexDB.Entites
{
    public class StudentExam
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = new Student();
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = new Exam();

        [DataType(DataType.DateTime)]
        public DateTime? StartTime { get; set; } 

        [DataType(DataType.DateTime)]
        public DateTime? EndTime { get; set; }  

        public int? Score { get; set; }
    }
}
