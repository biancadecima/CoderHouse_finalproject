using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSaleController : ControllerBase
    {
        //GetUsersSoldProducts: Bring all the products sold by a User. Returns a List of SoldProduct objects.
        [HttpGet("/api/ProductoVendido/{idUsuario}")]
        public List<ProductSale> GetUsersSoldProducts(long idUsuario)
        {
            List<ProductSale> usersSoldProducts = ProductSaleHandler.GetUsersSoldProducts(idUsuario);
            return usersSoldProducts;
        }

    }
}
