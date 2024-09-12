using Microsoft.AspNetCore.Mvc;
using stonic_producto_be.logic;
using stonic_producto_be.model;

namespace stonic_producto_be.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbarroteController
    {
        [HttpPost]
        public ReturnValue Post([FromBody] Producto item)
        {
            AbarroteLogic oProductoLogic = new AbarroteLogic();
            return oProductoLogic.Registrar(item);
        }
    }
}
