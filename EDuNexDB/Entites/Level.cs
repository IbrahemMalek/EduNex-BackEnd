using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDuNexDB.Entites
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }

        [Required]
        public string LevelName { get; set; }
    }

}
