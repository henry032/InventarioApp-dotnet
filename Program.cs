using InventarioApp.src.Factories;
using InventarioApp.Repositories;
using InventarioApp.Models;
using InventarioApp.Infrastructure;

Console.WriteLine("  === Integracion de Json ===  ");

var almacenamiento = new JsonInventarioStorage();

var productos = new List<Producto>
{
    new Producto{Id = 1,Nombre = "Laptop", Precio = 999.99m, Cantidad = 10, Categoria = CategoriaProducto.Electronica, Estado = EstadoProducto.Activo},
    new Producto{Id = 2,Nombre = "Agua", Precio = 10.99m, Cantidad = 25, Categoria = CategoriaProducto.Alimentos, Estado = EstadoProducto.Activo}
};

string ruta = "inventario_test.json";

almacenamiento.CrearBackup(ruta);
almacenamiento.Guardar(productos, ruta);

Console.WriteLine("Inventario guardado de manera correcta");

var productosCargados = almacenamiento.Cargar(ruta);
Console.WriteLine("Inventario cargado de manera correcta");

foreach (var p in productosCargados)
{
    Console.WriteLine($"Id: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Cantidad: {p.Cantidad}, Categoria: {p.Categoria}, Estado: {p.Estado}");
}
