using System.Threading.Tasks;


namespace Dictionary.Client
{
    public interface IDictionaryClient
    {
        Task<T> GetAsync<T>(string args);
    }
}
