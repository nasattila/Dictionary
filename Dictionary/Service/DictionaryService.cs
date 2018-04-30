using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Client;
using Dictionary.Model;


namespace Dictionary.Service
{
    public class DictionaryService : IDictionaryService
    {
        private static readonly string PREFIX_ARGS = "entries/";

        private readonly IDictionaryClient dictionaryClient;

        public DictionaryService(IDictionaryClient dictionaryClient)
        {
            this.dictionaryClient = dictionaryClient;
        }

        public async Task<MyDefinition> GetDefinitionAsync(string word, string language)
        {
            var args = PREFIX_ARGS + language + "/" + word;
            var result = await dictionaryClient.GetAsync<dynamic>(args);

            if (result == null)
            {
                return new MyDefinition();
            }

            var meanings = new List<string>();

            for(int i = 0; result.results != null && i < result.results.Count; i = i + 1)
            {
                for(int j = 0; result.results[i].lexicalEntries != null && j < result.results[i].lexicalEntries.Count; j = j + 1)
                {
                    for(int k = 0; result.results[i].lexicalEntries[j].entries != null && k < result.results[i].lexicalEntries[j].entries.Count; k = k + 1)
                    {
                        for(int m = 0; result.results[i].lexicalEntries[j].entries[k].senses != null && m < result.results[i].lexicalEntries[j].entries[k].senses.Count; m = m + 1)
                        {
                            for(int n = 0; result.results[i].lexicalEntries[j].entries[k].senses[m].definitions != null && n < result.results[i].lexicalEntries[j].entries[k].senses[m].definitions.Count; n = n + 1)
                            {
                                var meaning = result.results[i].lexicalEntries[j].entries[k].senses[m].definitions[n].ToString();

                                meanings.Add(meaning);
                            }
                        }
                    }
                }
            }

            var definition = new MyDefinition
            {
                Word = word,
                Meanings = meanings
            };

            return definition;
        }
    }
}
