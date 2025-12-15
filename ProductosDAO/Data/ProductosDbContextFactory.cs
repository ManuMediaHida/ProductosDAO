using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProductosDAO.Data;

public class ProductosDbContextFactory : IDesignTimeDbContextFactory<ProductosDbContext>
{
    public ProductosDbContext CreateDbContext(string[] args)
    {
        // Lee el appsettings.json del proyecto de la API
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ProductosAPI"))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var cs = configuration.GetConnectionString("ProductosDb");

        var optionsBuilder = new DbContextOptionsBuilder<ProductosDbContext>();
        optionsBuilder.UseSqlServer(cs);

        return new ProductosDbContext(optionsBuilder.Options);
    }
}
