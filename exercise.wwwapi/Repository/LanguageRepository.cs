using exercise.wwwapi.Data;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language AddLanguage(LanguagePost model)
        { 
            Language language = new Language
            {
                name = model.name
            };
            LanguageCollection.languages.Add(language);
            List<string> liste = new List<string>();
        }


        public IEnumerable<Language> GetAllLanguages()
        {
            return LanguageCollection.languages;
        }

        public Language GetLanguage(string name)
        {
            return LanguageCollection.languages.FirstOrDefault(x => x.name == name);
        }

        public Language UpdateLanguage(string name, LanguagePut model)
        {
            var target = GetLanguage(name);
            if (model.name != null) target.name = model.name; 
            return target;
        }
        public bool DeleteLanguage(string name)
        {
            return LanguageCollection.languages.RemoveAll(x => x.name == name) > 0 ? true : false; 
        }
    }
}
