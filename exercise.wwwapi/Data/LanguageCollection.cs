using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        public static List<Language> languages {get; set; } = new List<Language>();

        public static void Initialize()
        {
            languages.Add(new Language("Java"));
            languages.Add(new Language("C#"));
        }
    }
}
