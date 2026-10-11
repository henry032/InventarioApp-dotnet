namespace InventarioApp.Repositories;
using InventarioApp.Models;
using System.Linq;

public class InMemoryProductoRepository : IProductoRepository
{
    private readonly List<Producto> _productos = new();
    private int _proximoId = 1;
    public int Cantidad => _productos.Count;

    public bool Actualizar(Producto producto)
    {
        var verificacionProducto = ObtenerPorId(producto.Id);
         if (verificacionProducto == null) return false;

        verificacionProducto.Nombre = producto.Nombre;
        verificacionProducto.Precio = producto.Precio;
        verificacionProducto.Cantidad = producto.Cantidad;
        verificacionProducto.Categoria = producto.Categoria;
        verificacionProducto.Estado = producto.Estado;

        return true;
    }

    public void Agregar(Producto producto)
    {
        producto.Id = _proximoId++;
        _productos.Add(producto);
    }

    public bool Eliminar(int id)
    {
        var verificacionProducto = ObtenerPorId(id);
        if (verificacionProducto == null) return false;
        _productos.Remove(verificacionProducto);
        return true;
    }

    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Producto> ObtenerTodos()
    {
        return _productos.AsReadOnly();
    }

    public IEnumerable<Producto> BuscarCategoria(CategoriaProducto categoria)
    {
        return _productos.Where(p => p.Categoria == categoria);
    }

    public IEnumerable<Producto> BuscarNombre(string nombre)
    {
        return _productos.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Producto> BuscarRangoPrecio(decimal precioMinimo, decimal precioMaximo)
    {
        return _productos.Where(p => p.Precio >= precioMinimo && p.Precio <= precioMaximo);
    }

    public IEnumerable<string> ObtenerNombres()
    {
        return _productos.Select(p => p.Nombre);
    }

    public bool HayStockBajo()
    {
        return _productos.Any(p => p.Cantidad < 5);
    }

    public IEnumerable<Producto> ObtenerOrdenadosPorPrecio()
    {
        return _productos.OrderBy(p => p.Precio);
    }

    public IEnumerable<Producto> ObtenerTopPorPrecio(int cantidad)
    {
        return _productos.OrderByDescending(p => p.Precio).Take(cantidad);
    }

    public IEnumerable<IGrouping<CategoriaProducto, Producto>> AgruparPorCategoria()
    {
        return _productos.GroupBy(p => p.Categoria);
    }

    public Dictionary<CategoriaProducto, int> ContarPorCategoria()
    {
        return _productos.GroupBy(p => p.Categoria)
        .ToDictionary(g => g.Key, g => g.Count());
    }

    public decimal ObtenerValorTotalInventario()
    {
        return _productos.Sum(p => p.ValorTotal);
    }

    public decimal ObtenerPrecioPromedio()
    {
        if (_productos.Count == 0) return 0;
        return _productos.Average(p => p.Precio);
    }

    public Producto? ObtenerProductoMasCaro()
    {
        return _productos.MaxBy(p => p.Precio);
    }

	public Dictionary<CategoriaProducto, decimal> ObtenerValorPorCategoria()
	{
		return _productos
		.GroupBy(p => p.Categoria)
		.ToDictionary(g => g.Key, g => g.Sum(p => p.ValorTotal));
	}

	public IEnumerable<Producto> ObtenerStockBajo(int umbral = 5)
	{
		return _productos.Where(p => p.Cantidad < umbral);
	}
}