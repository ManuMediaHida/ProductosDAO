// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: ProductoSet
// Descripción: Modelo de datos (Entity) para EF Core. Mapea la tabla "ProductoSet".
// Notas:
//  - Usa DataAnnotations para definir claves, restricciones y longitudes.
//  - La PK idProducto es Identity (autoincremental).
//  - "oferta" se modela como short (útil si en BBDD es smallint/flag numérico).
// ==================================================================================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosDAO.Models
{
    [Table("ProductoSet")]
    public class ProductoSet
    {
        #region CAMPOS_BBDD

        /// <summary>
        /// Identificador del producto (PK). Generado automáticamente por la base de datos (Identity).
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducto { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [Required, MaxLength(150)]
        public string nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción corta del producto.
        /// </summary>
        [Required, MaxLength(500)]
        public string breveDescripcion { get; set; } = string.Empty;

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required]
        public double precio { get; set; }

        /// <summary>
        /// Stock disponible del producto.
        /// </summary>
        [Required]
        public int stock { get; set; }

        /// <summary>
        /// Indicador de oferta.
        /// </summary>
        /// <remarks>
        /// Si en BBDD se usa smallint (0/1), short encaja bien.
        /// Alternativa común: bool (si se cambia el tipo en BBDD o se configura conversión).
        /// </remarks>
        [Required]
        public short oferta { get; set; }

        #endregion

    }//Fin clase ProductoSet
}
