using System.Collections.Generic;

namespace Dictionary.Model
{
    public class MyLanguages
    {
        private ISet<MyLanguage> languages = new SortedSet<MyLanguage>();

        public ISet<string> Languages
        {
            get;
            set;
        }
    }
}
