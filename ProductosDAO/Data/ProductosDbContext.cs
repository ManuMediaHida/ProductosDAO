// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: ProductosDbContext
// Descripción: DbContext de Entity Framework Core para la base de datos de Productos.
// Notas:
//  - Expone DbSet<ProductoSet> para acceder a la tabla ProductoSet.
//  - La cadena de conexión se configura en Program.cs (ConnectionStrings:ProductosDb).
// ==================================================================================================

using Microsoft.EntityFrameworkCore;
using ProductosDAO.Models;

namespace ProductosDAO.Data
{
    public class ProductosDbContext : DbContext
    {
        /// <summary>
        /// Constructor del DbContext. Recibe opciones de configuración (proveedor, cadena de conexión, etc.).
        /// </summary>
        /// <param name="options">Opciones de configuración para ProductosDbContext.</param>
        public ProductosDbContext(DbContextOptions<ProductosDbContext> options) : base(options)
        {
        }//Fin método ProductosDbContext(DbContextOptions<ProductosDbContext> options)

        #region DBSETS

        /// <summary>
        /// Representa la tabla ProductoSet en base de datos.
        /// </summary>
        /// <remarks>
        /// EF Core mapeará esta propiedad al origen de datos configurado (SQL Server).
        /// </remarks>
        public DbSet<ProductoSet> ProductoSet => Set<ProductoSet>();

        #endregion
    }
}
