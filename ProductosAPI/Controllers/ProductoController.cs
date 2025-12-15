using Microsoft.AspNetCore.Mvc;
using ProductosDAO.Interfaces;
using ProductosDAO.Models;

namespace ProductosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProducto _productoService;

    public ProductoController(IProducto productoService)
    {
        _productoService = productoService;
    }

    // GET /Producto/{idProducto}
    [HttpGet("{idProducto}")]
    public ActionResult<ProductoSet> GetById(int idProducto)
    {
        var producto = _productoService.GetById(idProducto);
        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    // GET /Producto
    [HttpGet]
    public ActionResult<IEnumerable<ProductoSet>> GetAll()
    {
        var productos = _productoService.GetAll();
        return Ok(productos);
    }

    // POST /Producto
    [HttpPost]
    public ActionResult<ProductoSet> Create([FromBody] ProductoSet producto)
    {
        var creado = _productoService.Add(producto);
        return Ok(creado);
    }

    // PUT /Producto/{idProducto}
    [HttpPut("{idProducto}")]
    public ActionResult<ProductoSet> Update(int idProducto, [FromBody] ProductoSet producto)
    {
        var actualizado = _productoService.Update(idProducto, producto);
        if (actualizado == null)
            return NotFound();

        return Ok(actualizado);
    }

    // DELETE /Producto/{idProducto}
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
    }
}

