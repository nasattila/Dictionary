using Dictionary.Model;
using System.Threading.Tasks;


namespace Dictionary.Service
{
    public interface ILanguageService
    {
        Task<MyLanguages> GetSupportedLanguagesAsync();
    }
}
