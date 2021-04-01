using System.IO;
using System.Threading.Tasks;
using BNPKata;

namespace BNPKataConsole
{
    public class FilePrinter : IPrinter
    {
        public async Task Print(string raw, string location)
        {
            await File.WriteAllTextAsync(location, raw);
        }
    }
}