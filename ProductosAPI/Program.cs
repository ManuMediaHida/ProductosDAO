// ==================================================================================================
// mmediavilla_20251215 ProductosApi 1.0: Program
// Descripción: Punto de entrada de la Web API. Configura DI, Swagger, EF Core y el pipeline HTTP.
// Notas:
//  - Registra ProductosDbContext con SQL Server usando la cadena "ProductosDb".
//  - Registra IProducto -> ProductoService para la capa de servicios.
// ==================================================================================================

using Microsoft.EntityFrameworkCore;
using ProductosDAO.Data;
using ProductosDAO.Interfaces;
using ProductosDAO.Services;

// mmediavilla_20251215 ProductosApi 1.0: Creación del builder y carga de configuración.
var builder = WebApplication.CreateBuilder(args);

#region SERVICES_REGISTRATION

// mmediavilla_20251215 ProductosApi 1.0: Registro de controllers (endpoints REST).
builder.Services.AddControllers();

// mmediavilla_20251215 ProductosApi 1.0: Soporte para OpenAPI/Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// mmediavilla_20251215 ProductosApi 1.0: Registro del DbContext con SQL Server.
builder.Services.AddDbContext<ProductosDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductosDb")));

// mmediavilla_20251215 ProductosApi 1.0: Inyección del servicio de productos.
builder.Services.AddScoped<IProducto, ProductoService>();

#endregion

// mmediavilla_20251215 ProductosApi 1.0: Construcción de la aplicación.
var app = builder.Build();

#region HTTP_PIPELINE

// mmediavilla_20251215 ProductosApi 1.0: Middleware de Swagger solo en entorno Development.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// mmediavilla_20251215 ProductosApi 1.0: Mapeo de rutas de controllers.
app.MapControllers();

#endregion

// mmediavilla_20251215 ProductosApi 1.0: Arranque de la aplicación.
app.Run();
