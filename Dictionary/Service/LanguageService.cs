using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Client;
using Dictionary.Model;


namespace Dictionary.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly IDictionaryClient dictionaryClient;

        public LanguageService(IDictionaryClient dictionaryClient)
        {
            this.dictionaryClient = dictionaryClient;
        }

        public async Task<MyLanguages> GetSupportedLanguagesAsync()
        {
            var args = "languages";
            var result = await dictionaryClient.GetAsync<dynamic>(args);

            if (result == null)
            {
                return new MyLanguages();
            }

            var languages = new SortedSet<MyLanguage>();

            // TODO

            for (int i = 0; result.results != null && i < result.results.Count; i = i + 1)
            {

            }

            return result;
        }
    }
}
