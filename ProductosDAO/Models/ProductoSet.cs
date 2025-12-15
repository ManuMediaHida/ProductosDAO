using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosDAO.Models;

[Table("ProductoSet")]
public class ProductoSet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idProducto { get; set; }

    [Required, MaxLength(150)]
    public string nombre { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string breveDescripcion { get; set; } = string.Empty;

    [Required]
    public double precio { get; set; }

    [Required]
    public int stock { get; set; }

    [Required]
    public short oferta { get; set; }
}
