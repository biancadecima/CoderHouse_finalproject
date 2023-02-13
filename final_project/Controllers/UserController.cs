using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using final_project;

namespace final_project.Controllers
{

    /*Modificar usuario: Recibe como parámetro un json con todos los datos del objeto usuario y se deberá modificar el mismo con los datos nuevos 
     * (No crear uno nuevo)*/

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPut("/api/Usuario")]
        public void ModifyUser([FromBody] User user)
        {
            UserHandler.UpdateUser(user);
        }
    }
}
