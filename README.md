Listado de Productos
Descripción

Solución en ASP.NET Core para mostrar un listado de productos en el navegador, utilizando una arquitectura por capas.

Estructura del proyecto

La solución contiene tres proyectos:

ProductosDAO (Class Library)
Contiene la lógica de negocio y el acceso a datos mediante Entity Framework Core.

ProductosAPI (ASP.NET Core Web API)
Expone una API REST para gestionar los productos y permite su prueba mediante Swagger.

ProductosWeb (ASP.NET Core MVC)
Consume la API y muestra el listado de productos en una página web.
