using Microsoft.EntityFrameworkCore;
using ProductosDAO.Data;
using ProductosDAO.Interfaces;
using ProductosDAO.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductosDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductosDb")));

builder.Services.AddScoped<IProducto, ProductoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
