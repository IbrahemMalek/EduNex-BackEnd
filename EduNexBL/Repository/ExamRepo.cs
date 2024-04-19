using EduNexBL.Base;
using EduNexBL.DTOs;
using EduNexBL.ENums;
using EduNexBL.IRepository;
using EduNexDB.Context;
using EduNexDB.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNexBL.Repository
{
    public class ExamRepo : Repository<Exam>, IExam
    {
        private readonly EduNexContext _context;

        public ExamRepo(EduNexContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam>> GetAllExamsWithQuestions()
        {
            return await _context.Exams
                .Include(exam => exam.Questions)
                    .ThenInclude(question => question.Answers)
                .ToListAsync();
        }

        public async Task<Exam> GetExamByIdWithQuestionsAndAnswers(int examId)
        {
            return await _context.Exams
                .Include(exam => exam.Questions)
                    .ThenInclude(question => question.Answers)
                .FirstOrDefaultAsync(exam => exam.ExamId == examId);
        }

        public async Task<ExamStartResult> StartExam(int studentId, int examId)
        {
            var exam = await GetExamByIdWithQuestionsAndAnswers(examId);
            if (!IsExamAvailable(exam))
                return ExamStartResult.NotAvailable;

            if (IsStudentStartedExam(studentId, examId))
                return ExamStartResult.AlreadyStarted;

            var studentExam = new StudentExam
            {
                StudentId = studentId,
                ExamId = examId,
                StartTime = DateTime.Now
            };

            _context.StudentExam.Add(studentExam);
            await _context.SaveChangesAsync();

            return ExamStartResult.Success;
        }

        public async Task<ExamSubmitResult> SubmitExam(ExamSubmissionDto examSubmissionDto)
        {
            if (!IsStudentStartedExam(examSubmissionDto.StudentId, examSubmissionDto.ExamId))
                return ExamSubmitResult.NotStarted;

            await SaveSubmissionToDB(examSubmissionDto);
            EndStudentExam(examSubmissionDto.StudentId, examSubmissionDto.ExamId);

            int studentGrade = CalculateStudentGrade(examSubmissionDto);
            return ExamSubmitResult.Success;
        }

        private bool IsExamAvailable(Exam exam)
        {
            var currentTime = DateTime.Now;
            return currentTime >= exam.StartDateTime && currentTime <= exam.EndDateTime;
        }

        private bool IsStudentStartedExam(int studentId, int examId)
        {
            return _context.StudentExam
                .Any(se => se.StudentId == studentId && se.ExamId == examId && se.StartTime != null);
        }

        private async Task SaveSubmissionToDB(ExamSubmissionDto examSubmissionDto)
        {
            var submissions = new List<StudentsAnswersSubmissions>();

            foreach (var answer in examSubmissionDto.Answers)
            {
                foreach (var selectedAnswerId in answer.SelectedAnswersIds)
                {
                    var submission = new StudentsAnswersSubmissions
                    {
                        StudentId = examSubmissionDto.StudentId,
                        ExamId = examSubmissionDto.ExamId,
                        QuestionId = answer.QuestionId,
                        AnswerId = selectedAnswerId
                    };
                    await _context.StudentsAnswersSubmissions.AddAsync(submission);
                }
            }

            await _context.SaveChangesAsync();
        }

        private void EndStudentExam(int studentId, int examId)
        {
            var studentExam = _context.StudentExam
                .FirstOrDefault(se => se.StudentId == studentId && se.ExamId == examId);
            if (studentExam != null)
                studentExam.EndTime = DateTime.Now;

            _context.SaveChanges();
        }

        private int CalculateStudentGrade(ExamSubmissionDto examSubmissionDto)
        {
            int studentGrade = 0;

            foreach (var submittedQuestion in examSubmissionDto.Answers)
            {
                if (IsCorrectAnswer(submittedQuestion))
                {
                    var question = _context.Questions
                        .FirstOrDefault(q => q.QuestionId == submittedQuestion.QuestionId);
                    if (question != null)
                        studentGrade += question.Points;
                }
            }

            return studentGrade;
        }

        private bool IsCorrectAnswer(SubmittedQuestionDto submittedQuestionDto)
        {
            var submittedAnswerIds = submittedQuestionDto.SelectedAnswersIds;
            var correctAnswerIds = GetCorrectAnswerIdsForQuestion(submittedQuestionDto.QuestionId);

            if (submittedAnswerIds == null || submittedAnswerIds.Count != correctAnswerIds.Count)
                return false;

            var sortedSubmittedAnswerIds = submittedAnswerIds.OrderBy(id => id).ToList();
            var sortedCorrectAnswerIds = correctAnswerIds.OrderBy(id => id).ToList();

            for (int i = 0; i < sortedCorrectAnswerIds.Count; i++)
            {
                if (sortedCorrectAnswerIds[i] != sortedSubmittedAnswerIds[i])
                    return false;
            }

            return true;
        }

        private List<int> GetCorrectAnswerIdsForQuestion(int questionId)
        {
            return _context.Answers
                .Where(answer => answer.QuestionId == questionId && answer.IsCorrect)
                .Select(answer => answer.AnswerId)
                .ToList();
        }
    }
}
