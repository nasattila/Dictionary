using Dictionary.Client;
using Dictionary.Model;
using Dictionary.Service;
using System.Collections.Generic;


namespace Dictionary.ViewModel
{
    class MainViewModel : MainViewModelBase
    {
        private static readonly string SEARCHING = "SEARCHING...";
        private static readonly string NOT_FOUND = "No results were found for this word...";

        private string word = "";  // stores the entered word
        private string language = "en";
        private IList<string> meanings = new List<string>();  // stores the meanings of the word
        private string status = "";  // stores the current status of searching for the word

        public string Word
        {
            get
            {
                return word;
            }
            set
            {
                if (value != word)
                {
                    word = value;

                    if (word != null && word != "")
                    {
                        FindResult();  // search for word upon entering text
                    }
                    else if(Meanings != null)
                    {
                        Meanings = new List<string>();
                    }

                    OnPropertyChanged("Word");  // notify about change
                }
            }
        }

        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                if (value != language)
                {
                    language = value;

                    OnPropertyChanged("Language");  // notify about change
                }
            }
        }

        public IList<string> Meanings
        {
            get
            {
                return meanings;
            }
            set
            {
                meanings = value;

                OnPropertyChanged("Meanings");  // notify about change
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    status = value;

                    OnPropertyChanged("Status");  // notify about change
                }
            }
        }

        public async void FindResult()
        {
            Status = "";

            if (Meanings != null && Meanings.Count > 0)
            {
                Meanings = new List<string>();  // clear any previously stored meanings
            }

            if (Word != "")
            {
                Status = SEARCHING;

                var dictionaryClient = new DictionaryClient();
                var dictionaryService = new DictionaryService(dictionaryClient);
                var getDefinitionTask = await dictionaryService.GetDefinitionAsync(Word, Language);

                if (getDefinitionTask != null)
                {
                    Meanings = getDefinitionTask.Meanings;  // update found meanings

                    if (Meanings != null && Meanings.Count > 0)
                    {
                        Status = "";
                    }
                    else
                    {
                        Status = NOT_FOUND;
                    }
                }
                else
                {
                    Status = NOT_FOUND;
                }
            }
        }
    }
}
