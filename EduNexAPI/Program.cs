
using EduNexBL.AutoMapper;
using EduNexBL.Base;
using EduNexBL.IRepository;
using EduNexBL.Repository;
using EduNexBL.UnitOfWork;
using EduNexDB.Context;
using EduNexDB.Entites;
using Microsoft.EntityFrameworkCore;

namespace EduNexAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<EduNexContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IExam, ExamRepo>();
            builder.Services.AddScoped<IStudent, StudentRepo>();
            builder.Services.AddScoped<IStudentExam, StudentExamRepo>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
