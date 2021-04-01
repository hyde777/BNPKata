using System.Threading.Tasks;

namespace BNPKata
{
    public interface IPrinter
    {
        Task Print(string raw, string location);
    }
}