using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Dictionary.Client
{
    public class DictionaryClient : IDictionaryClient
    {
        private static readonly string APP_ID = "8e1e757d";  // application ID
        private static readonly string APP_KEY = "2a3dc0e1ebbc9f5874206bfd4020dab6";  // API key

        private readonly HttpClient httpClient;

        public DictionaryClient()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://od-api.oxforddictionaries.com/api/v1/"),  // set base address to API
            };

            httpClient.DefaultRequestHeaders.Clear();
            // add application ID and API to header:
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("app_id", APP_ID);
            httpClient.DefaultRequestHeaders.Add("app_key", APP_KEY);
            //
        }

        public async Task<T> GetAsync<T>(string args)
        {
            var response = await httpClient.GetAsync(args);  // get results from API

            if(!response.IsSuccessStatusCode || response == null)  // if retrieval is unsuccessful
            {
                return default(T);
            }

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);  // deserialize JSON result and return
        }
    }
}
