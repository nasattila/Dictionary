using Dictionary.ViewModel;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dictionary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MainViewModel mainViewModel = new MainViewModel();

            DataContext = mainViewModel;  // set data context

            mainViewModel.GetSourceLanguages(language_selector);  // populate combo box with source languages
        }
    }
}
