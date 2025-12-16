// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: ProductoService
// Descripción: Implementación de IProducto usando Entity Framework Core (ProductosDbContext).
// Notas:
//  - Contiene la lógica de acceso a datos para CRUD de ProductoSet.
//  - Devuelve null cuando no existe el registro (GetById/Update).
//  - Delete devuelve string.Empty si OK, o mensaje de error si falla.
// ==================================================================================================

using Microsoft.EntityFrameworkCore;
using ProductosDAO.Data;
using ProductosDAO.Interfaces;
using ProductosDAO.Models;

namespace ProductosDAO.Services
{
    public class ProductoService : IProducto
    {
        private readonly ProductosDbContext _context;

        /// <summary>
        /// Constructor del servicio de productos.
        /// </summary>
        /// <param name="context">DbContext inyectado para acceso a base de datos.</param>
        public ProductoService(ProductosDbContext context)
        {
            _context = context;

        }//Fin método ProductoService(ProductosDbContext context)

        #region SELECT_RESULTADOS_INDIVIDUALES

        /// <summary>
        /// Obtiene un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto.</param>
        /// <returns>Producto si existe; null si no existe.</returns>
        public ProductoSet? GetById(int idProducto)
        {
            return _context.ProductoSet.Find(idProducto);

        }//Fin método GetById(int idProducto)

        #endregion

        #region SELECT_RESULTADOS_MULTIPLES

        /// <summary>
        /// Obtiene el listado completo de productos.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        public IList<ProductoSet> GetAll()
        {
            return _context.ProductoSet
                .AsNoTracking()  
                .ToList();

        }//Fin método GetAll()

        #endregion

        #region INSERT

        /// <summary>
        /// Inserta un nuevo producto en base de datos.
        /// </summary>
        /// <param name="producto">Producto a insertar.</param>
        /// <returns>Producto insertado (con ID asignado si aplica).</returns>
        public ProductoSet Add(ProductoSet producto)
        {
            _context.ProductoSet.Add(producto);
            _context.SaveChanges();
            return producto;

        }//Fin método Add(ProductoSet producto)

        #endregion

        #region UPDATE

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="idProducto">ID del producto a actualizar.</param>
        /// <param name="producto">Datos nuevos del producto.</param>
        /// <returns>Producto actualizado si existe; null si no existe.</returns>
        public ProductoSet? Update(int idProducto, ProductoSet producto)
        {
            var existente = _context.ProductoSet.Find(idProducto);
            if (existente == null) return null;

            // mmediavilla_20251215 ProductosApi 1.0: Copia de propiedades actualizables.
            existente.nombre = producto.nombre;
            existente.breveDescripcion = producto.breveDescripcion;
            existente.precio = producto.precio;
            existente.stock = producto.stock;
            existente.oferta = producto.oferta;

            _context.SaveChanges();
            return existente;

        }//Fin método Update(int idProducto, ProductoSet producto)

        #endregion

        #region DELETE

        /// <summary>
        /// Elimina un producto.
        /// </summary>
        /// <param name="producto">Producto a eliminar.</param>
        /// <returns>
        /// string.Empty si se elimina correctamente;
        /// en caso de error devuelve el mensaje de la excepción.
        /// </returns>
        public string Delete(ProductoSet producto)
        {
            try
            {
                _context.ProductoSet.Remove(producto);
                _context.SaveChanges();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }//Fin método Delete(ProductoSet producto)

        #endregion
    }
}
