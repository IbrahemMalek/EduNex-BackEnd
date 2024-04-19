﻿using EduNexBL.Base;
using EduNexBL.IRepository;
using EduNexDB.Context;
using EduNexDB.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexBL.Repository
{
    public class StudentRepo : Repository<Student>, IStudent
    {
        private readonly EduNexContext _Context;

        public StudentRepo(EduNexContext Context) : base(Context)
        {
            _Context = Context;
        }


    }
}