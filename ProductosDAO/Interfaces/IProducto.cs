using ProductosDAO.Models;

namespace ProductosDAO.Interfaces;

public interface IProducto
{
    ProductoSet? GetById(int idProducto);
    IList<ProductoSet> GetAll();
    ProductoSet Add(ProductoSet producto);
    ProductoSet? Update(int idProducto, ProductoSet producto);
    string Delete(ProductoSet producto);
}
