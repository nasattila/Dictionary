using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Client;
using Dictionary.Model;


namespace Dictionary.Service
{
    public class LanguageService : ILanguageService
    {
        private static readonly string PREFIX_ARGS = "languages";

        private readonly IDictionaryClient dictionaryClient;

        public LanguageService(IDictionaryClient dictionaryClient)
        {
            this.dictionaryClient = dictionaryClient;
        }

        public async Task<MyLanguages> GetSourceLanguagesAsnyc()
        {
            var args = PREFIX_ARGS;
            var result = await dictionaryClient.GetAsync<dynamic>(args);

            if (result == null)
            {
                return new MyLanguages();
            }

            var languages = new MyLanguages
            {
                Languages = new SortedSet<string>()
            };

            for (int i = 0; result.results != null && i < result.results.Count; i = i + 1)
            {
                if (result.results[i].type.ToString() == "monolingual")
                {
                    languages.Languages.Add(result.results[i].sourceLanguage.id.ToString());
                }
            }

            return languages;
        }
    }
}
