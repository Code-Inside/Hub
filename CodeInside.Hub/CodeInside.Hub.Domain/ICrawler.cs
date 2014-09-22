using System.Threading.Tasks;

namespace CodeInside.Hub.Domain
{
    public interface ICrawler<T> 
    {
        T DoWork();
        Task<T> DoWorkAsync();
    }
}