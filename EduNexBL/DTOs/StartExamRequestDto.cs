using System.ComponentModel.DataAnnotations;

namespace EduNexAPI.Controllers
{
    public class StartExamRequestDto
    {
        [Required]
        public int StudentId { get; set; }
    }
}