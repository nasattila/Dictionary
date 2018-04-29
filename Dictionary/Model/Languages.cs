using Newtonsoft.Json;
using System.Collections.Generic;


namespace Dictionary.Model
{
    public class SourceLanguage
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }
    }

    public class TargetLanguage
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }
    }

    public class Result_Languages
    {
        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("sourceLanguage")]
        public SourceLanguage sourceLanguage { get; set; }

        [JsonProperty("targetLanguage")]
        public TargetLanguage targetLanguage { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class Languages
    {
        [JsonProperty("metadata")]
        public Metadata metadata { get; set; }

        [JsonProperty("results")]
        public IList<Result_Languages> results { get; set; }
    }
}
