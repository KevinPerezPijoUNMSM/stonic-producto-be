using Microsoft.AspNetCore.Mvc;
using stonic_producto_be.logic;
using stonic_producto_be.model;

namespace stonic_producto_be.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController
    {
        [HttpPost]
        public ReturnValue Post([FromBody] Producto item)
        {
            ProductoLogic oProductoLogic = new ProductoLogic();
            return oProductoLogic.Registrar(item);
        }
    }
}
