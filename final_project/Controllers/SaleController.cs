using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        //GetSales: You must bring all the sales of the base that a User has made. It receives the User id as a URL parameter and returns a list of Sale objects.
        [HttpGet("/api/Venta/{idUsuario}")]
        public List<Sale> GetSales(long idUsuario) 
        {
            List<Sale> salesByUser = SaleHandler.GetUserSale(idUsuario);
            return salesByUser;
        }


        /*LoadSale: Receives a list of products and the UserID number of the person who made it, 
         * first load a new sale in the database, then load the received products in the ProductSold base one by one on one side, 
         * and discount the stock in the product base on the other.*/

        [HttpPost("/api/Venta/{idUsuario}")]
        public void LoadSale(long idUsuario, [FromBody] List<Product> soldProducts)
        {
            SaleHandler.LoadSale(idUsuario, soldProducts);
        }

    }
}
