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
        private static readonly string NOT_FOUND = "No results were found for this word... " + ENTER;
        private static readonly string NO_CONNECTION = "Please check your connection...";

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

                            // DelayAction(1000, new Action(() => { this.FindResult(); }));  // delay search for more correct thread return order

                            DelayAction(1000);

                            if(word == lowerCase)  // check if word has changed
                            {
                                FindResult();  // search for word upon entering text
                            }
    
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

                        DelayAction(500, new Action(() => { this.FindResult(); }));  // delay search for more correct thread return order
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

        public async void FindResult()  // find definition(s) and put them in the Meanings list
        {
            if (Word != "")
            {
                Status = SEARCHING;

                var dictionaryClient = new DictionaryClient();  // create client
                var dictionaryService = new DictionaryService(dictionaryClient);  // create service

                try
                {
                    var getDefinitionTask = await dictionaryService.GetDefinitionAsync(Word, SourceLanguage);  // get definitions asynchronously

                    if (getDefinitionTask != null && getDefinitionTask.Meanings != null)  // if definitions were found
                    {
                        Meanings = new ObservableCollection<string>(getDefinitionTask.Meanings);  // update found meanings

                        if (Meanings != null && Meanings.Count > 0)
                        {
                            Status = ENTER;
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
                catch (Exception exception)
                {
                    Status = NO_CONNECTION;
                }
            }
            else
            {
                Status = ENTER;
            }
        }

        public async void GetSourceLanguages(ComboBox comboBox)
        {
            var dictionaryClient = new DictionaryClient();  // create client
            var languageService = new LanguageService(dictionaryClient);  // create service

            try
            {
                var getLanguagesTask = await languageService.GetSourceLanguagesAsnyc();  // get source languages asyunchronously

                if (getLanguagesTask != null && getLanguagesTask.Languages != null)  // if source languages were found
                {
                    var languages = new ObservableCollection<string>();  // transfer supported language strings here

                    foreach (string language in getLanguagesTask.Languages)
                    {
                        languages.Add(language);
                    }

                    SourceLanguages = languages;  // set SourceLanguages to those found

                    comboBox.SelectedIndex = SourceLanguages.IndexOf("en");  // set initial value of combo box to English
                }
                else
                {
                    SourceLanguages = new ObservableCollection<string>();
                }
            }
            catch (Exception exception)
            {
                Status = NO_CONNECTION;
            }
        }

        private void ClearMeanings()  // clear Meanings list
        {
            if(Meanings != null && Meanings.Count > 0)
            {
                Meanings.Clear();
            }
        }

        public static void DelayAction(int milliseconds)  // timer
        {
            var timer = new DispatcherTimer();

            timer.Tick += delegate
            {
                timer.Stop();
            };

            timer.Interval = TimeSpan.FromMilliseconds(milliseconds);

            timer.Start();
        }

        public static void DelayAction(int milliseconds, Action action)  // timer
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
