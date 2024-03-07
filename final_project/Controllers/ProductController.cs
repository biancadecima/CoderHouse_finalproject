using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using final_project;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //GetProducts: You must bring all the products loaded into the base by a User. The userid comes as a parameter of the URL.
        [HttpGet("/api/Producto/{idUsuario}")]
        public List<Product> GetUsersProducts(long idUsuario)
        {
            List<Product> usersProducts = ProductHandler.GetUsersProducts(idUsuario);
            return usersProducts;
        }

        /*CreateProduct: Receives a Product object in the request body and creates a new user in the database.*/
        [HttpPost("/api/Producto")]
        public void InsertProduct([FromBody] Product product)
        {
            ProductHandler.InsertProduct(product);
        }

        /*ModifyProduct: Receives a Product object in the request body and must be modified in the database*/
        [HttpPut("/api/Producto")]
        public void ModifyProduct([FromBody] Product product)
        {
            ProductHandler.UpdateProduct(product);
        }

        /*DeleteProduct: Receives the Id number of a product to delete as a URL parameter and must delete it from the database. */
        [HttpDelete("/api/Producto/{id}")]
        public void DeleteProduct(long id)
        {
            ProductHandler.DeleteProduct(id);
        }
    }
}
