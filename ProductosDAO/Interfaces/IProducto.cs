// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: IProducto
// Descripción: Contrato (interfaz) para la gestión CRUD de productos.
// Notas:
//  - La implementa la capa de servicios (p.ej. ProductoService).
//  - Se inyecta en los Controllers mediante DI.
//  - Métodos que pueden no encontrar entidad devuelven null (GetById/Update).
// ==================================================================================================

using ProductosDAO.Models;

namespace ProductosDAO.Interfaces
{
    public interface IProducto
    {
        #region SELECT_RESULTADOS_INDIVIDUALES

        /// <summary>
        /// Obtiene un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto.</param>
        /// <returns>Producto si existe; null si no existe.</returns>
        ProductoSet? GetById(int idProducto);

        #endregion

        #region SELECT_RESULTADOS_MULTIPLES

        /// <summary>
        /// Obtiene el listado completo de productos.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        IList<ProductoSet> GetAll();

        #endregion

        #region INSERT

        /// <summary>
        /// Inserta un nuevo producto.
        /// </summary>
        /// <param name="producto">Producto a insertar.</param>
        /// <returns>Producto insertado (normalmente con ID asignado).</returns>
        ProductoSet Add(ProductoSet producto);

        #endregion

        #region UPDATE

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="idProducto">ID del producto a actualizar.</param>
        /// <param name="producto">Datos nuevos del producto.</param>
        /// <returns>Producto actualizado si existe; null si no existe.</returns>
        ProductoSet? Update(int idProducto, ProductoSet producto);

        #endregion

        #region DELETE

        /// <summary>
        /// Elimina un producto.
        /// </summary>
        /// <param name="producto">Producto a eliminar.</param>
        /// <returns>
        /// Cadena vacía si se elimina correctamente.
        /// Si hay error de validación/reglas, devuelve un mensaje describiéndolo.
        /// </returns>
        string Delete(ProductoSet producto);

        #endregion
    }
}
