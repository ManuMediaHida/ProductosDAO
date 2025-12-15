using Microsoft.EntityFrameworkCore;
using ProductosDAO.Models;

namespace ProductosDAO.Data;

public class ProductosDbContext : DbContext
{
    public ProductosDbContext(DbContextOptions<ProductosDbContext> options) : base(options) { }

    public DbSet<ProductoSet> ProductoSet => Set<ProductoSet>();
}
