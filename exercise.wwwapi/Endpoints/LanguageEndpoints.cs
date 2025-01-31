using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app) 
        {
            var laguages = app.MapGroup("/languages");
            laguages.MapPost("/", AddLanguage);
            laguages.MapGet("/", GetAllLanguages);
            laguages.MapGet("/{name}", GetLanguage);
            laguages.MapDelete("/{name}", DeleteLanguage);
            laguages.MapPut("/{name}", UpdateLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAllLanguages(ILanguageRepository repository)
        {
            var result = repository.GetAllLanguages();
            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
        {
            var result = repository.GetLanguage(name);
            return Results.Ok(result);
        }
        private static async Task<IResult> AddLanguage(ILanguageRepository repository, LanguagePost model)
        {
            Language language = repository.AddLanguage(model);
            return Results.Created($"https://localhost:7009/students/{language.name}", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, LanguagePut model)
        {
            try
            {
                var target = repository.GetLanguage(name);
                if (target != null) return Results.NotFound();
                target = repository.UpdateLanguage(name, model);
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
        private static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
        {
            try
            {
                var model = repository.GetLanguage(name);
                if (repository.DeleteLanguage(name)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", name = model.name });
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

    }
}
