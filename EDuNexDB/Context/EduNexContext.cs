using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduNexDB.Entites;
using Microsoft.EntityFrameworkCore;

namespace EduNexDB.Context
{
    public class EduNexContext : DbContext
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<StudentExam> StudentExam { get; set; }
        public DbSet<StudentsAnswersSubmissions> StudentsAnswersSubmissions { get; set; }
        public EduNexContext(DbContextOptions<EduNexContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentExam>()
            .HasKey(se => new { se.StudentId, se.ExamId });
            modelBuilder.Entity<StudentExam>()
                  .HasOne(se => se.Student)
                  .WithMany(s => s.StudentExams)
                  .HasForeignKey(se => se.StudentId)
                  .OnDelete(DeleteBehavior.NoAction); // Specify delete behavior

            modelBuilder.Entity<StudentExam>()
                .HasOne(se => se.Exam)
                .WithMany(e => e.StudentExams)
                .HasForeignKey(se => se.ExamId)
                .OnDelete(DeleteBehavior.NoAction); // Specify delete behavior


            modelBuilder.Entity<StudentsAnswersSubmissions>()
       .HasKey(s => s.Id);

            modelBuilder.Entity<StudentsAnswersSubmissions>()
                .HasOne(s => s.Exam)
                .WithMany()
                .HasForeignKey(s => s.ExamId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete for Exam relationship

            modelBuilder.Entity<StudentsAnswersSubmissions>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete for Exam relationship


            modelBuilder.Entity<StudentsAnswersSubmissions>()
                .HasOne(s => s.Question)
                .WithMany()
                .HasForeignKey(s => s.QuestionId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete for Exam relationship


            modelBuilder.Entity<StudentsAnswersSubmissions>()
                .HasOne(s => s.Answer)
                .WithMany()
                .HasForeignKey(s => s.AnswerId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete for Exam relationship


            base.OnModelCreating(modelBuilder);
        }


    }
}
