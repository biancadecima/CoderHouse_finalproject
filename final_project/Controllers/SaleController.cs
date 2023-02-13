using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        /*Cargar Venta: Recibe una lista de productos y el numero de IdUsuario de quien la efectuó, primero cargar una nueva venta en la base de datos, 
        luego debe cargar los productos recibidos en la base de ProductosVendidos uno por uno por un lado, y descontar el stock en la base de productos por el otro.*/

        [HttpPost("/api/Venta/{idUsuario}")]
        public void LoadSale(long idUsuario, List<Product> soldProducts)
        {
            SaleHandler.LoadSale(idUsuario, soldProducts);
        }

    }
}
