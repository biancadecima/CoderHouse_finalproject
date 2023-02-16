using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSaleController : ControllerBase
    {
        //Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario.Devuelve un Lista de objetos ProductoVendido.
        [HttpGet("/api/ProductoVendido/{idUsuario}")]
        public List<ProductSale> GetUsersSoldProducts(long idUsuario)
        {
            List<ProductSale> usersSoldProducts = ProductSaleHandler.GetUsersSoldProducts(idUsuario);
            return usersSoldProducts;
        }

    }
}
