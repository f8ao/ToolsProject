using Microsoft.Data.SqlClient;

namespace Tools.Data
{
    public sealed class Connection
    {
        private readonly string connectionString = string.Empty;
        public Connection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            connectionString = builder.GetSection("ConnectionStrings:DefaultConnection").Value
                ?? throw new InvalidOperationException("El string 'DefaultConnection no fue hallado.'");
        }
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
