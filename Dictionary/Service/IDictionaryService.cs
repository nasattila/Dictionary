using Dictionary.Model;
using System.Threading.Tasks;


namespace Dictionary.Service
{
    public interface IDictionaryService
    {
        Task<MyDefinition> GetDefinitionAsync(string word, string language);
    }
}
