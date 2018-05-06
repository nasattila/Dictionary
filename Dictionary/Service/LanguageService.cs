using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Client;
using Dictionary.Model;


namespace Dictionary.Service
{
    public class LanguageService : ILanguageService  // service having to do with languages
    {
        private static readonly string PREFIX_ARGS = "languages";

        private readonly IDictionaryClient dictionaryClient;

        public LanguageService(IDictionaryClient dictionaryClient)
        {
            this.dictionaryClient = dictionaryClient;
        }

        public async Task<MyLanguages> GetSourceLanguagesAsnyc()
        {
            var args = PREFIX_ARGS;  // add path to base address
            var result = await dictionaryClient.GetAsync<dynamic>(args);  // get results (deserialized JSON objects)

            if (result == null)  // if result is empty
            {
                return new MyLanguages();
            }

            var languages = new MyLanguages  // store definition strings to return here
            {
                Languages = new SortedSet<string>()
            };

            // get languages from deserialized JSON:
            for (int i = 0; result.results != null && i < result.results.Count; i = i + 1)
            {
                if (result.results[i].type.ToString() == "monolingual")
                {
                    languages.Languages.Add(result.results[i].sourceLanguage.id.ToString());  // add language to the list
                }
            }
            //

            return languages;
        }
    }
}
