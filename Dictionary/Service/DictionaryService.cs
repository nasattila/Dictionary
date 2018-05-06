using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Client;
using Dictionary.Model;


namespace Dictionary.Service
{
    public class DictionaryService : IDictionaryService  // service having to do with definitions
    {
        private static readonly string PREFIX_ARGS = "entries";

        private readonly IDictionaryClient dictionaryClient;

        public DictionaryService(IDictionaryClient dictionaryClient)
        {
            this.dictionaryClient = dictionaryClient;
        }

        public async Task<MyDefinition> GetDefinitionAsync(string word, string language)
        {
            var args = PREFIX_ARGS + "/" + language + "/" + word;  // add path to base address
            var result = await dictionaryClient.GetAsync<dynamic>(args);  // get results (deserialized JSON objects)

            if (result == null)  // if result is empty
            {
                return new MyDefinition();
            }

            var meanings = new List<string>();  // store definition strings to return here

            // get definitions from deserialized JSON:
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

                                meanings.Add(meaning);  // add meaning to the list
                            }
                        }
                    }
                }
            }
            //

            var definition = new MyDefinition  // create object to store definitions of word
            {
                Word = word,
                Meanings = meanings
            };

            return definition;
        }
    }
}
