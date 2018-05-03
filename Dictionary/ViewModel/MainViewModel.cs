using Dictionary.Client;
using Dictionary.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dictionary.ViewModel
{
    class MainViewModel : MainViewModelBase
    {
        private static readonly string ENTER = "Enter a word to see its definition(s).";
        private static readonly string SEARCHING = "SEARCHING...";
        private static readonly string NOT_FOUND = "No results were found for this word...";

        private string word = "";  // stores the entered word
        private string language = "en";
        private IList<string> meanings = new ObservableCollection<string>();  // stores the meanings of the word
        private string status = ENTER;  // stores the current status of searching for the word

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
                    else
                    {
                        Status = ENTER;

                        ClearMeanings();
                    }

                    ClearMeanings();  // clear any previously stored meanings

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

            ClearMeanings();  // clear any previously stored meanings

            if (Word != "")
            {
                Status = SEARCHING;

                var dictionaryClient = new DictionaryClient();
                var dictionaryService = new DictionaryService(dictionaryClient);
                var getDefinitionTask = await dictionaryService.GetDefinitionAsync(Word, Language);

                if (getDefinitionTask != null && getDefinitionTask.Meanings != null)
                {
                    Meanings = new ObservableCollection<string>(getDefinitionTask.Meanings);  // update found meanings

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

                if (Word == "")
                {
                    Status = ENTER;

                    ClearMeanings();
                }
            }
            else
            {
                Status = ENTER;
            }
        }

        private void ClearMeanings()
        {
            if(Meanings != null && Meanings.Count > 0)
            {
                Meanings.Clear();
            }
        }
    }
}
