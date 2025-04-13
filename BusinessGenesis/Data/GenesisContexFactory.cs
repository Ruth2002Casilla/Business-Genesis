using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using BusinessGenesis.Data;  // Asegúrate de que el espacio de nombres sea correcto

namespace BusinessGenesis.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<GenesisContex>
    {
        public GenesisContex CreateDbContext(string[] args)
        {
            // Leer la configuración del appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Obtener la cadena de conexión
            var connectionString = configuration.GetConnectionString("ConStr");

            // Configurar las opciones del DbContext
            var optionsBuilder = new DbContextOptionsBuilder<GenesisContex>();
            optionsBuilder.UseSqlite(connectionString);  // Cambiar a UseSqlite

            return new GenesisContex(optionsBuilder.Options);
        }
    }
}
