using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using ProductosDAO.Models;

namespace ProductosWeb.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(IConfiguration config)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(config["ApiBaseUrl"]!)
        };
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _httpClient.GetFromJsonAsync<List<ProductoSet>>("Producto");
        return View(productos ?? new List<ProductoSet>());
    }
}
