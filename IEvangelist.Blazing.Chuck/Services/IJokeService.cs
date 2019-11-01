using System.Threading.Tasks;

namespace IEvangelist.Blazing.Chuck.Services
{
    public interface IJokeService
    {
        ValueTask<string> GetJokeAsync();
    }
}