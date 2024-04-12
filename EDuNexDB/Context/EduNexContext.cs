using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EduNexDB.Context
{
    public class EduNexContext:DbContext
    {
        public EduNexContext(DbContextOptions<EduNexContext> options) : base(options)
        {

        }



    }
}
