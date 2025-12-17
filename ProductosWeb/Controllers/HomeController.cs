// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: HomeController (ProductosWeb)
// Descripción: Controlador MVC que consume la API de Productos y pinta el listado en la vista Index.
// Notas:
//  - Usa HttpClient para llamar a la API (endpoint: GET /Producto).
//  - BaseAddress se obtiene de configuración: "ApiBaseUrl" (appsettings del proyecto web).
//  - Si la API no devuelve datos, se retorna una lista vacía para evitar nulls en la vista.
// ==================================================================================================

using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using ProductosDAO.Models;

namespace ProductosWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor del controlador. Inicializa HttpClient con la base URL de la API.
        /// </summary>
        /// <param name="config">Configuración de la aplicación (para leer ApiBaseUrl).</param>
        public HomeController(IConfiguration config)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config["ApiBaseUrl"]!)
            };

        }//Fin método HomeController(IConfiguration config)

        #region SELECT_RESULTADOS_MULTIPLES

        /// <summary>
        /// Acción principal. Obtiene el listado de productos desde la API y lo pasa a la vista.
        /// </summary>
        /// <returns>Vista Index con la lista de productos.</returns>
        public async Task<IActionResult> Index()
        {
            var productos = await _httpClient.GetFromJsonAsync<List<ProductoModel>>("Producto");
            return View(productos ?? new List<ProductoModel>());

        }//Fin método Index()

        #endregion
    }
}
