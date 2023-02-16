using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        //Traer Ventas: Debe traer todas las ventas de la base que ha efectuado un Usuario.
        //Recibe como parámetro URL el id de Usuario y devuleve una lista de objetos Venta.
        [HttpGet("/api/Venta/{idUsuario}")]
        public List<Sale> GetSales(long idUsuario) 
        {
            List<Sale> salesByUser = SaleHandler.GetUserSale(idUsuario);
            return salesByUser;
        }


        /*Cargar Venta: Recibe una lista de productos y el numero de IdUsuario de quien la efectuó, primero cargar una nueva venta en la base de datos, 
        luego debe cargar los productos recibidos en la base de ProductosVendidos uno por uno por un lado, y descontar el stock en la base de productos por el otro.*/

        [HttpPost("/api/Venta/{idUsuario}")]
        public void LoadSale(long idUsuario, [FromBody] List<Product> soldProducts)
        {
            SaleHandler.LoadSale(idUsuario, soldProducts);
        }

    }
}
