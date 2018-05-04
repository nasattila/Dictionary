using System.Collections.Generic;


namespace Dictionary.Model
{
    public class MyDefinition
    {
        public string Word
        {
            get;
            set;
        }

        public IList<string> Meanings
        {
            get;
            set;
        }
    }
}
