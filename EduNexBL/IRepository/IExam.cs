﻿using EduNexBL.Base;
using EduNexBL.ENums;
using EduNexDB.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexBL.IRepository
{
    public interface IExam : IRepository<Exam>
    {
        Task<IEnumerable<Exam>> GetAllExamsWithQuestions();
        Task<Exam> GetExamByIdWithQuestionsAndAnswers(int examId);
        Task<ExamStartResult> StartExam(int studentId, int examId);


    }
}
