using Microsoft.Extensions.Configuration;
using System.IO;

namespace api.agenda.de.compromissos
{
    public static class Configuration
    {
        public static string getConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            IConfiguration Configuration = builder.Build();
            return Configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
