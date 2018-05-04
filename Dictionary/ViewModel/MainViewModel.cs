using Dictionary.Client;
using Dictionary.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Dictionary.ViewModel
{
    class MainViewModel : MainViewModelBase
    {
        private static readonly string ENTER = "Enter a word to see its definition(s) (if any).";
        private static readonly string SEARCHING = "SEARCHING...";
        private static readonly string NOT_FOUND = "No results were found for this word...";

        private string word = "";  // stores the entered word
        private IList<string> sourceLanguages = new ObservableCollection<string>();
        private string sourceLanguage = "en";
        private IList<string> targetLanguages = new ObservableCollection<string>();
        private string targetLanguage = "en";
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
                if (value != null)
                {
                    var lowerCase = value.ToLower();  // convert text to lower case

                    if (lowerCase != word)
                    {
                        word = lowerCase;

                        ClearMeanings();  // clear any previously stored meanings

                        if (word != "")
                        {
                            Status = SEARCHING;

                            // FindResult();  // search for word upon entering text

                            DelayAction(1000, new Action(() => { this.FindResult(); }));  // delay search for more correct thread return order
                        }
                        else
                        {
                            Status = ENTER;
                        }

                        OnPropertyChanged("Word");  // notify about change
                    }
                }
                else
                {
                    Status = ENTER;

                    ClearMeanings();
                }
            }
        }

        public IList<string> SourceLanguages
        {
            get
            {
                return sourceLanguages;
            }
            set
            {
                sourceLanguages = value;

                OnPropertyChanged("SourceLanguages");  // notify about change
            }
        }

        public string SourceLanguage
        {
            get
            {
                return sourceLanguage;
            }
            set
            {
                if (value != sourceLanguage)
                {
                    sourceLanguage = value;

                    ClearMeanings();

                    if (Word != null && Word != "")
                    {
                        ClearMeanings();

                        Status = SEARCHING;

                        DelayAction(1000, new Action(() => { this.FindResult(); }));  // delay search for more correct thread return order
                    }

                    OnPropertyChanged("SourceLanguage");  // notify about change
                }
            }
        }

        public IList<string> TargetLanguages
        {
            get
            {
                return targetLanguages;
            }
            set
            {
                targetLanguages = value;

                OnPropertyChanged("TargetLanguages");  // notify about change
            }
        }

        public string TargetLanguage
        {
            get
            {
                return targetLanguage;
            }
            set
            {
                if (value != targetLanguage)
                {
                    targetLanguage = value;

                    OnPropertyChanged("TargetLanguage");  // notify about change
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
            if (Word != "")
            {
                Status = SEARCHING;

                var dictionaryClient = new DictionaryClient();
                var dictionaryService = new DictionaryService(dictionaryClient);
                var getDefinitionTask = await dictionaryService.GetDefinitionAsync(Word, SourceLanguage);

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

                    ClearMeanings();  // clear any previously stored meanings
                }
            }
            else
            {
                Status = ENTER;
            }
        }

        public async void GetSourceLanguages(ComboBox comboBox)
        {
            var dictionaryClient = new DictionaryClient();
            var languageService = new LanguageService(dictionaryClient);
            var getLanguagesTask = await languageService.GetSourceLanguagesAsnyc();

            if (getLanguagesTask != null && getLanguagesTask.Languages != null)
            {
                var languages = new ObservableCollection<string>();

                foreach (string language in getLanguagesTask.Languages)
                {
                    languages.Add(language);
                }

                SourceLanguages = languages;

                comboBox.SelectedIndex = SourceLanguages.IndexOf("en");
            }
            else
            {
                SourceLanguages = new ObservableCollection<string>();
            }
        }

        private void ClearMeanings()
        {
            if(Meanings != null && Meanings.Count > 0)
            {
                Meanings.Clear();
            }
        }

        public static void DelayAction(int milliseconds, Action action)
        {
            var timer = new DispatcherTimer();

            timer.Tick += delegate
            {
                action.Invoke();

                timer.Stop();
            };

            timer.Interval = TimeSpan.FromMilliseconds(milliseconds);

            timer.Start();
        }
    }
}
