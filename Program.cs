// ============================================================
// SISTEMA DE INVENTARIO - Clase 1.1
// Estado: Mensaje de bienvenida
// ============================================================

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

if (args.Length > 0)
{
	switch (args[0].ToLower())
	{
		case "--help":
			MostrarAyuda();
			Environment.Exit(0);
			break;
		case "--version":
			Console.WriteLine($"Version del proyecto: {version}");
			Environment.Exit(0);
			break;
		default:
			Console.WriteLine($"ERROR: Comando desconocido: {args[0]}");
			Console.WriteLine("Utiliza el comando --help para ver los comandos disponibles");
			Environment.Exit(1);
			break;
	}
}

int cantidadProductos = 0;
decimal valorTotalInventario = 0.00m;
bool sistemaActivo = true;
string nombreSistema =  "Gestion de inventario";
decimal precio = 19.99m;

Console.WriteLine("Estado del sistema ");
Console.WriteLine($"Nombre del sistema: {nombreSistema}");
Console.WriteLine($"Productos: {cantidadProductos}");
Console.WriteLine($"Valor del inventario: {valorTotalInventario:N2}");
Console.WriteLine($"Sistema activo: {(sistemaActivo ? "Si" : "No")}");

Console.Write("Ingrese una cantid: ");
string? entradaCantidad = Console.ReadLine();

if (int.TryParse(entradaCantidad, out int cantidad))
{
	Console.Write($"Cantidad valida: {cantidad}\n");
	cantidadProductos = cantidad;
}
else
{
	Console.WriteLine("Error, debe ingresar un numero entero");
}

Console.Write("Ingrese un precion: ");
string? entradaPrecio = Console.ReadLine();

if (decimal.TryParse(entradaPrecio, out decimal precioProducto))
{
	Console.Write($"Precio valido: {precioProducto:C}\n");
	valorTotalInventario = cantidadProductos * precioProducto;
	Console.WriteLine($"Nuevo valor de inventario {valorTotalInventario:N2}");
}
else
{
	Console.WriteLine("Error, debe ingresar un numero decimal.");
}

//MostrarBanner();

// Modo interactivo si no ingresa argumentos

Console.Write("Ingrese comando o 'salir' para abandonar: ");
string? entrada = Console.ReadLine();

if (string.IsNullOrWhiteSpace(entrada) || entrada.ToLower() == "salir")
{
	Console.WriteLine("Saliendo del programa...");
	Environment.Exit(0);
}

/*
Console.WriteLine("Estructura del proyecto:");
Console.WriteLine(" InventarioApp/");
Console.WriteLine("  |--program.cs");
Console.WriteLine("  |--InventarioApp.csproj");
Console.WriteLine("  |--gitignore");
Console.WriteLine("  |--README.md");
Console.WriteLine("  |--src/");
Console.WriteLine("    |--Models/ (Proxima clase");

Console.WriteLine("Estado: Proyecto inicializado");
Console.WriteLine("Carpeta src/ creada");
Console.WriteLine("Metadatos configurados");
Console.WriteLine();
Console.WriteLine("Proximo paso: Agregar argumentos CLI y configuracion de repositorio en Github");
*/

void MostrarBanner()
{
    Console.WriteLine("╔══════════════════════════════════════╗");
    Console.WriteLine("║   SISTEMA DE GESTIÓN DE INVENTARIO   ║");
    Console.WriteLine("╚══════════════════════════════════════╝");
    Console.WriteLine();
    Console.WriteLine($"Versión: {version}");
    Console.WriteLine($".NET: {Environment.Version}");
    Console.WriteLine($"Sistema: {Environment.OSVersion.Platform}");
    Console.WriteLine();
}

void MostrarAyuda()
{
    Console.WriteLine("USO: InventarioApp [comando] [opciones]");
    Console.WriteLine();
    Console.WriteLine("COMANDOS:");
    Console.WriteLine("  --help, -h      Muestra esta ayuda");
    Console.WriteLine("  --version, -v   Muestra la version del programa");
    Console.WriteLine();
    Console.WriteLine("EJEMPLOS:");
    Console.WriteLine(" dotnet run -- --help");
    Console.WriteLine(" dotnet run -- --version");
}
