using Newtonsoft.Json;
using System.Collections.Generic;


namespace Dictionary.Model
{
    public class Metadata
    {
    }

    public class DerivativeOf
    {
        [JsonProperty("domains")]
        public IList<string> domains { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }

        [JsonProperty("regions")]
        public IList<string> regions { get; set; }

        [JsonProperty("registers")]
        public IList<string> registers { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }
    }

    public class Derivative
    {
        [JsonProperty("domains")]
        public IList<string> domains { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }

        [JsonProperty("regions")]
        public IList<string> regions { get; set; }

        [JsonProperty("registers")]
        public IList<string> registers { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }
    }

    public class GrammaticalFeature
    {
        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class Note
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class Pronunciation
    {
        [JsonProperty("audioFile")]
        public string audioFile { get; set; }

        [JsonProperty("dialects")]
        public IList<string> dialects { get; set; }

        [JsonProperty("phoneticNotation")]
        public string phoneticNotation { get; set; }

        [JsonProperty("phoneticSpelling")]
        public string phoneticSpelling { get; set; }

        [JsonProperty("regions")]
        public IList<string> regions { get; set; }
    }

    public class CrossReference
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class Translation
    {
        [JsonProperty("domains")]
        public IList<string> domains { get; set; }

        [JsonProperty("grammaticalFeatures")]
        public IList<GrammaticalFeature> grammaticalFeatures { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }

        [JsonProperty("notes")]
        public IList<Note> notes { get; set; }

        [JsonProperty("regions")]
        public IList<string> regions { get; set; }

        [JsonProperty("registers")]
        public IList<string> registers { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }
    }

    public class Example
    {
        [JsonProperty("definitions")]
        public IList<string> definitions { get; set; }

        [JsonProperty("domains")]
        public IList<string> domains { get; set; }

        [JsonProperty("notes")]
        public IList<Note> notes { get; set; }

        [JsonProperty("regions")]
        public IList<string> regions { get; set; }

        [JsonProperty("registers")]
        public IList<string> registers { get; set; }

        [JsonProperty("senseIds")]
        public IList<string> senseIds { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("translations")]
        public IList<Translation> translations { get; set; }
    }

    public class Subsens
    {
    }

    public class ThesaurusLink
    {
        [JsonProperty("entry_id")]
        public string entry_id { get; set; }

        [JsonProperty("sense_id")]
        public string sense_id { get; set; }
    }

    public class VariantForm
    {
        [JsonProperty("regions")]
        public IList<string> regions { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }
    }

    public class Sens
    {
        [JsonProperty("crossReferenceMarkers")]
        public IList<string> crossReferenceMarkers { get; set; }

        [JsonProperty("crossReferences")]
        public IList<CrossReference> crossReferences { get; set; }

        [JsonProperty("definitions")]
        public IList<string> definitions { get; set; }

        [JsonProperty("domains")]
        public IList<string> domains { get; set; }

        [JsonProperty("examples")]
        public IList<Example> examples { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("notes")]
        public IList<Note> notes { get; set; }

        [JsonProperty("pronunciations")]
        public IList<Pronunciation> pronunciations { get; set; }

        [JsonProperty("regions")]
        public IList<string> regions { get; set; }

        [JsonProperty("registers")]
        public IList<string> registers { get; set; }

        [JsonProperty("short_definitions")]
        public IList<string> short_definitions { get; set; }

        [JsonProperty("subsenses")]
        public IList<Subsens> subsenses { get; set; }

        [JsonProperty("thesaurusLinks")]
        public IList<ThesaurusLink> thesaurusLinks { get; set; }

        [JsonProperty("translations")]
        public IList<Translation> translations { get; set; }

        [JsonProperty("variantForms")]
        public IList<VariantForm> variantForms { get; set; }
    }

    public class Entry
    {
        [JsonProperty("etymologies")]
        public IList<string> etymologies { get; set; }

        [JsonProperty("grammaticalFeatures")]
        public IList<GrammaticalFeature> grammaticalFeatures { get; set; }

        [JsonProperty("homographNumber")]
        public string homographNumber { get; set; }

        [JsonProperty("notes")]
        public IList<Note> notes { get; set; }

        [JsonProperty("pronunciations")]
        public IList<Pronunciation> pronunciations { get; set; }

        [JsonProperty("senses")]
        public IList<Sens> senses { get; set; }

        [JsonProperty("variantForms")]
        public IList<VariantForm> variantForms { get; set; }
    }

    public class LexicalEntry
    {
        [JsonProperty("derivativeOf")]
        public IList<DerivativeOf> derivativeOf { get; set; }

        [JsonProperty("derivatives")]
        public IList<Derivative> derivatives { get; set; }

        [JsonProperty("entries")]
        public IList<Entry> entries { get; set; }

        [JsonProperty("grammaticalFeatures")]
        public IList<GrammaticalFeature> grammaticalFeatures { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }

        [JsonProperty("lexicalCategory")]
        public string lexicalCategory { get; set; }

        [JsonProperty("notes")]
        public IList<Note> notes { get; set; }

        [JsonProperty("pronunciations")]
        public IList<Pronunciation> pronunciations { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("variantForms")]
        public IList<VariantForm> variantForms { get; set; }
    }

    public class Result_Definitions
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }

        [JsonProperty("lexicalEntries")]
        public IList<LexicalEntry> lexicalEntries { get; set; }

        [JsonProperty("pronunciations")]
        public IList<Pronunciation> pronunciations { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("word")]
        public string word { get; set; }
    }

    public class Definition
    {
        [JsonProperty("metadata")]
        public Metadata metadata { get; set; }

        [JsonProperty("results")]
        public IList<Result_Definitions> results { get; set; }
    }

}
