using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using final_project;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Inicio de sesión: Se le pasa como parámetro el nombre del usuario y la contraseña,
        //buscar en la base de datos si el usuario existe y si coincide con la contraseña lo devuelve.
        [HttpGet("/api/Usuario/{usuario}/{contrasena}")]
        public User LogIn(string usuario, string contrasena)
        {
            User user = new User();
            user = UserHandler.LogIn(usuario, contrasena);
            return user;
        }

        //Debe recibir un nombre del usuario en la URL, se debe buscarlo en la base de datos y devolver un objeto Usuario.
        [HttpGet("/api/Usuario/{usuario}")]
        public User GetUser(string usuario)
        {
            User user = new User();
            user = UserHandler.GetUser(usuario);
            return user;
        }

        //Crear Usuario: Recibe un json tipo Usuario y debe dar un alta inmediata del usuario en la base de datos
        //(Opcional validar que no se repita el mismo nombre de usuario)
        [HttpPost("/api/Usuario")]
        public void InsertUser([FromBody] User usuario)
        {
            UserHandler.InsertUser(usuario);
        }

        /*Modificar usuario: Recibe como parámetro un json con todos los datos del objeto usuario y se deberá modificar el mismo con los datos nuevos 
        * (No crear uno nuevo)*/
        [HttpPut("/api/Usuario")]
        public void ModifyUser([FromBody] User user)
        {
            UserHandler.UpdateUser(user);
        }

        //Eliminar Usuario: Recibe el ID del usuario a eliminar en la URL y lo deberá eliminar de la base de datos.
        [HttpDelete("/api/Usuario/{id}")]
        public void DeleteUser(long id)
        {
            UserHandler.DeleteUser(id);
        }
    }
}
