using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.DataProtection.Repositories;
using exercise.wwwapi.Repository;
using exercise.wwwapi.DTO;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("/students");
            students.MapPost("/", AddStudent);
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstName}", GetStudentByName);
            students.MapDelete("/{firstName}", DeleteStudentByName);
            students.MapPut("/{firstName}", UpdateStudentByName);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IStudentRepository repository)
        {
            var result = repository.GetAllStudents();
            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentByName(IStudentRepository repository, string firstName)
        {
            var result = repository.GetStudentByName(firstName);
            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IStudentRepository repository, StudentPost model)
        {
            Student student = repository.AddStudent(model);
            return Results.Created($"https://localhost:7009/students/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudentByName(IStudentRepository repository, string firstName, StudentPut model)
        {
            try
            {
                var target = repository.GetStudentByName(firstName);
                if (target != null) return Results.NotFound();
                target = repository.UpdateStudentByName(firstName, model);
                return Results.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudentByName(IStudentRepository repository, string firstName)
        {
            try
            {
                var model = repository.GetStudentByName(firstName);
                if (repository.DeleteStudentByName(firstName)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", FirstName = model.FirstName, LastName = model.LastName });
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }




    }

}
