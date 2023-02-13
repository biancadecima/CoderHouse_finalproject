using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using final_project;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /*Crear producto: Recibe un producto como parámetro, deberá crearlo, puede ser void*/
        [HttpPost("/api/Producto")]
        public void CreateProduct([FromBody] Product product)
        {
            ProductHandler.InsertProduct(product);
        }

        /*Modificar producto: Recibe un producto como parámetro, debe modificarlo con la nueva información.*/
        [HttpPut("/api/Producto")]
        public void ModifyProduct([FromBody] Product product)
        {
            ProductHandler.UpdateProduct(product);
        }

        /* Eliminar producto: Recibe un id de producto a eliminar y debe eliminarlo de la base de datos (eliminar antes sus productos vendidos tambien, sino no lo podrá hacer).*/
        [HttpDelete("/api/Producto/{id}")]
        public void DeleteProduct([FromBody] long id)
        {
            ProductHandler.DeleteProduct(id);
        }
    }
}
