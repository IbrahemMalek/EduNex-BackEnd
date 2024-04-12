using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexDB.Entites
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string TeacherName { get; set; }

        public string ProfilePhoto { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string FacebookAccount { get; set; }

        [Required]
        public string Religion { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string NationalId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
