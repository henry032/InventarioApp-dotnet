using InventarioApp.src.Factories;
using InventarioApp.Repositories;
using InventarioApp.Models;
using InventarioApp.Infrastructure;

Console.WriteLine("  === Sistema de inventario ===  ");

var fileManager = new FileManager();
string contenido = "Inventario actualizado";
fileManager.Escribir("inventario.txt", contenido);

string leerContenido = fileManager.Leer("inventario.txt");
Console.WriteLine($"Contenido: {leerContenido}");

var repositorio = new InMemoryProductoRepository();

Producto laptop = ProductoFactory.Crear(nombre: "Laptop Dell XPS 13", precio: 1200, cantidad: 5, CategoriaProducto.Electronica);
Producto mouse = ProductoFactory.Crear(nombre: "Mouse Logitech MX Master", precio: 99, cantidad: 20, CategoriaProducto.Electronica);
Producto teclado = ProductoFactory.Crear(nombre: "Teclado Mecánico", precio: 150, cantidad: 3, CategoriaProducto.Electronica);
Producto silla = ProductoFactory.Crear(nombre: "Silla Ergonómica Herman Miller", precio: 500, cantidad: 8, CategoriaProducto.Muebles);
Producto escritorio = ProductoFactory.Crear(nombre: "Escritorio Stand-up", precio: 300, cantidad: 2, CategoriaProducto.Muebles);

repositorio.Agregar(laptop);
repositorio.Agregar(mouse);
repositorio.Agregar(teclado);
repositorio.Agregar(silla);
repositorio.Agregar(escritorio);

Console.WriteLine($"Productos agregados: {repositorio.Cantidad}\n");

var electronicos = repositorio.BuscarCategoria(CategoriaProducto.Electronica);
Console.WriteLine("Productos de electronica:");

foreach (var prod in electronicos)
{
    Console.WriteLine($"{prod.Nombre}: ${prod.Precio}");
}

var conMouse = repositorio.BuscarNombre("mouse");
Console.WriteLine("\nProductos con 'mouse':");
foreach (var prod in conMouse)
{
    Console.WriteLine($"{prod.Nombre}");
}

var nombres = repositorio.ObtenerNombres();
Console.WriteLine($"\nTodos los nombres: {string.Join(", ", nombres)}");

var hayStockBajo = repositorio.HayStockBajo();
Console.WriteLine($"\nStock bajo: {hayStockBajo}");