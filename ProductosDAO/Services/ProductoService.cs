using ProductosDAO.Data;
using ProductosDAO.Interfaces;
using ProductosDAO.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductosDAO.Services;

public class ProductoService : IProducto
{
    private readonly ProductosDbContext _context;

    public ProductoService(ProductosDbContext context)
    {
        _context = context;
    }

    public ProductoSet? GetById(int idProducto)
    {
        return _context.ProductoSet.Find(idProducto);
    }

    public IList<ProductoSet> GetAll()
    {
        return _context.ProductoSet.ToList();
    }

    public ProductoSet Add(ProductoSet producto)
    {
        _context.ProductoSet.Add(producto);
        _context.SaveChanges();
        return producto;
    }

    public ProductoSet? Update(int idProducto, ProductoSet producto)
    {
        var existente = _context.ProductoSet.Find(idProducto);
        if (existente == null) return null;

        existente.nombre = producto.nombre;
        existente.breveDescripcion = producto.breveDescripcion;
        existente.precio = producto.precio;
        existente.stock = producto.stock;
        existente.oferta = producto.oferta;

        _context.SaveChanges();
        return existente;
    }

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
    }
}
