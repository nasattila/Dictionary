using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Dictionary.Client
{
    public class DictionaryClient : IDictionaryClient
    {
        private static readonly string APP_ID = "8e1e757d";
        private static readonly string APP_KEY = "2a3dc0e1ebbc9f5874206bfd4020dab6";

        private readonly HttpClient httpClient;

        public DictionaryClient()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://od-api.oxforddictionaries.com/api/v1/"),
            };

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("app_id", APP_ID);
            httpClient.DefaultRequestHeaders.Add("app_key", APP_KEY);
        }

        public async Task<T> GetAsync<T>(string args)
        {
            var response = await httpClient.GetAsync(args);

            if(!response.IsSuccessStatusCode || response == null)
            {
                return default(T);
            }

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
