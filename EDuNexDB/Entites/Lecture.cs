﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexDB.Entites
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }

        [Required]
        public string LectureTitle { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }

}
