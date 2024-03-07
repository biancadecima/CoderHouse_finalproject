using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using final_project;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //LogIn: The user name and password are passed as parameters, search the database if the user exists and if it matches the password it returns it.
        [HttpGet("/api/Usuario/{usuario}/{contrasena}")]
        public User LogIn(string usuario, string contrasena)
        {
            User user = new User();
            user = UserHandler.LogIn(usuario, contrasena);
            return user;
        }

        //GetUser: It must receive a user's name in the URL, look it up in the database and return a User object.
        [HttpGet("/api/Usuario/{usuario}")]
        public User GetUser(string usuario)
        {
            User user = new User();
            user = UserHandler.GetUser(usuario);
            return user;
        }

        //CreateUser: Receives a User-type json and must immediately register the user in the database
        [HttpPost("/api/Usuario")]
        public void InsertUser([FromBody] User usuario)
        {
            UserHandler.InsertUser(usuario);
        }

        /*ModifyUser: All user data will be received by a json and it must be modified with the new data (Do not create a new one).*/
        [HttpPut("/api/Usuario")]
        public void ModifyUser([FromBody] User user)
        {
            UserHandler.UpdateUser(user);
        }

        //DeleteUser: Receives the ID of the user to delete in the URL and must delete it from the database.
        [HttpDelete("/api/Usuario/{id}")]
        public void DeleteUser(long id)
        {
            UserHandler.DeleteUser(id);
        }
    }
}
