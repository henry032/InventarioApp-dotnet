namespace InventarioApp.Repositories;

using InventarioApp.Models;

///	<summary>
/// Contrato para almacenamiento de productos
/// Define las operaciones basicas CRUD.
/// </summary>

public interface IProductoRepository
{
	void Agregar(Producto producto);

	Producto? ObtenerPorId(int id);

	IEnumerable<Producto> ObtenerTodos();

	bool Actualizar(Producto producto);

	bool Eliminar(int id);

	int Cantidad { get; }
}