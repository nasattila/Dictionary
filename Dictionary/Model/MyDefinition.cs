using System.Collections.Generic;


namespace Dictionary.Model
{
    public class MyDefinition
    {
        private string word = "";
        private IList<string> meanings = new List<string>();

        public string Word
        {
            get;
            set;
        }

        public List<string> Meanings
        {
            get;
            set;
        }
    }
}
