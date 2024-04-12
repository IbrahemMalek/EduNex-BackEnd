using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexDB.Entites
{
    public enum City
    {
        [Display(Name = "New York")]
        NewYork,
        [Display(Name = "Los Angeles")]
        LosAngeles,
        [Display(Name = "Chicago")]
        Chicago,
        [Display(Name = "Houston")]
        Houston,
        [Display(Name = "Other")]
        Other
    }
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string ParentPhoneNumber { get; set; }

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

        [ForeignKey("Level")]
        public int LevelId { get; set; }
        public Level? Level { get; set; }
    }
}
