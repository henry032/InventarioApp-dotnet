namespace InventarioApp.Models;

/// <summary>
/// Ciclo de vida del producto en el inventario
/// </summary>

public enum EstadoProducto
{
	//Disponible para venta
	Activo,
	// Temporalmente no disponible
	Inactivo,
	// Retirado permanentemente del catalogo
	Descontinuado

}