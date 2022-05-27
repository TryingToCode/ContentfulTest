using Statiq.App;
using Statiq.Web;
using System.Threading.Tasks;

namespace ContentfulTest
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>
          await Bootstrapper
            .Factory
            .CreateWeb(args)
            .RunAsync();
    }
}
