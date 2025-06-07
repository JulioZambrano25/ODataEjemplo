using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using ODataEjemplo.Models;

namespace ODataEjemplo.Controllers
{
    public class ProductosController : ODataController
    {
        private static IList<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200, Categoria = "Electrónica" },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25, Categoria = "Accesorios" },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 45, Categoria = "Accesorios" },
            new Producto { Id = 4, Nombre = "Monitor", Precio = 300, Categoria = "Electrónica" }
        };

        [EnableQuery]
        public ActionResult<IQueryable<Producto>> Get()
        {
            return Ok(productos.AsQueryable());
        }
    }
}
