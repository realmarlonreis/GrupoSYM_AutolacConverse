using System.IO;
using System.Reflection;

namespace GRUPOSYM_ProjetoConverse.Helpers
{
    public static class TestHelper
    {
        public static string Chromedriver => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
