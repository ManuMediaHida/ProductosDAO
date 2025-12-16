// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: ProductosDbContextFactory
// Descripción: Factoría de DbContext para tiempo de diseño (migraciones EF Core).
// Uso típico: dotnet ef migrations add / dotnet ef database update
// Notas:
//  - EF Core la usa cuando no puede construir el DbContext vía DI.
//  - Lee appsettings.json del proyecto ProductosAPI para obtener "ConnectionStrings:ProductosDb".
//  - El SetBasePath apunta a ../ProductosAPI (relativo a la carpeta actual donde se ejecuta el comando).
// ==================================================================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProductosDAO.Data
{
    public class ProductosDbContextFactory : IDesignTimeDbContextFactory<ProductosDbContext>
    {
        /// <summary>
        /// Crea una instancia de ProductosDbContext para operaciones de diseño (migraciones).
        /// </summary>
        /// <param name="args">Argumentos de línea de comandos.</param>
        /// <returns>Instancia configurada de ProductosDbContext.</returns>
        public ProductosDbContext CreateDbContext(string[] args)
        {
            // mmediavilla_20251215 ProductosApi 1.0: Construye IConfiguration leyendo el appsettings.json de la API.
            // Nota: Directory.GetCurrentDirectory() suele ser el proyecto desde el que ejecutas "dotnet ef".
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ProductosAPI"))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // mmediavilla_20251215 ProductosApi 1.0: Obtiene la connection string definida como "ProductosDb".
            var cs = configuration.GetConnectionString("ProductosDb");

            // mmediavilla_20251215 ProductosApi 1.0: Configura el DbContext para SQL Server.
            var optionsBuilder = new DbContextOptionsBuilder<ProductosDbContext>();
            optionsBuilder.UseSqlServer(cs);

            return new ProductosDbContext(optionsBuilder.Options);

        }//Fin método CreateDbContext(string[] args)
    }
}
