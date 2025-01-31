using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        // Language
        Language  AddLanguage(LanguagePost language);
        IEnumerable<Language> GetAllLanguages();
        Language GetLanguage(string name);
        Language UpdateLanguage(string name, LanguagePut model);
        bool DeleteLanguage(string name);

    }
}
