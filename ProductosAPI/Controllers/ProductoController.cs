// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: ProductoController
// Descripción: Controlador Web API para exponer endpoints CRUD de ProductoSet.
// Notas:
//  - El controlador delega la lógica en IProducto (servicio/capa de acceso).
//  - Mantener el controller “fino”: validaciones de negocio y acceso a datos fuera de aquí.
// ==================================================================================================

using Microsoft.AspNetCore.Mvc;
using ProductosDAO.Interfaces;
using ProductosDAO.Models;

namespace ProductosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _productoService;

        /// <summary>
        /// Constructor del controlador de productos.
        /// </summary>
        /// <param name="productoService">Servicio inyectado que gestiona la operativa CRUD de productos.</param>
        public ProductoController(IProducto productoService)
        {
            _productoService = productoService;

        }//Fin método ProductoController(IProducto productoService)

        #region SELECT_RESULTADOS_INDIVIDUALES

        /// <summary>
        /// Obtiene un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto.</param>
        /// <returns>Devuelve 200 (OK) con el producto si existe, o 404 (NotFound) si no existe.</returns>
        [HttpGet("{idProducto}")]
        public ActionResult<ProductoSet> GetById(int idProducto)
        {
            var producto = _productoService.GetById(idProducto);
            if (producto == null)
                return NotFound();

            return Ok(producto);

        }//Fin método GetById(int idProducto)

        #endregion

        #region SELECT_RESULTADOS_MULTIPLES

        /// <summary>
        /// Obtiene el listado completo de productos.
        /// </summary>
        /// <returns>Devuelve 200 (OK) con el listado de productos.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProductoSet>> GetAll()
        {
            var productos = _productoService.GetAll();
            return Ok(productos);

        }//Fin método GetAll()

        #endregion

        #region INSERT

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="producto">Producto a crear (recibido en el body).</param>
        /// <returns>Devuelve 200 (OK) con el producto creado.</returns>
        [HttpPost]
        public ActionResult<ProductoSet> Create([FromBody] ProductoSet producto)
        {
            var creado = _productoService.Add(producto);
            return Ok(creado);

        }//Fin método Create(ProductoSet producto)

        #endregion

        #region UPDATE

        /// <summary>
        /// Actualiza un producto existente por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a actualizar.</param>
        /// <param name="producto">Datos actualizados del producto (recibidos en el body).</param>
        /// <returns>Devuelve 200 (OK) con el producto actualizado, o 404 (NotFound) si no existe.</returns>
        [HttpPut("{idProducto}")]
        public ActionResult<ProductoSet> Update(int idProducto, [FromBody] ProductoSet producto)
        {
            var actualizado = _productoService.Update(idProducto, producto);
            if (actualizado == null)
                return NotFound();

            return Ok(actualizado);

        }//Fin método Update(int idProducto, ProductoSet producto)

        #endregion

        #region DELETE

        /// <summary>
        /// Elimina un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a eliminar.</param>
        /// <returns>
        /// Devuelve 200 (OK) si se elimina correctamente,
        /// 404 (NotFound) si el producto no existe,
        /// o 400 (BadRequest) si el servicio devuelve un mensaje de error.
        /// </returns>
        [HttpDelete("{idProducto}")]
        public ActionResult Delete(int idProducto)
        {
            var producto = _productoService.GetById(idProducto);
            if (producto == null)
                return NotFound();

            var result = _productoService.Delete(producto);
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok();

        }//Fin método Delete(int idProducto)

        #endregion
    }
}

