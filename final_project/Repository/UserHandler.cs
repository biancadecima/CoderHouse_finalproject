using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    internal class UserHandler : SqlHandler
    {
        public static void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("update Usuario set Nombre = @name, Apellido = @surname, NombreUsuario = @username, Contraseña = @password, Mail = @mail  where Id = @id", connection);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@mail", user.Mail);
                command.Parameters.AddWithValue("@id", user.Id);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        //Traer Usuario: Recibe como parámetro un nombre del usuario, buscarlo en la base de datos
        //y devolver el objeto con todos sus datos(Esto se hará para la pagina en la que se
        //mostrara los datos del usuario y en la página para modificar sus datos).

        public static User GetUser(long id)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from Usuario where Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    user.Id = reader.GetInt64(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.Username = reader.GetString(3);
                    user.Password = reader.GetString(4);
                    user.Mail = reader.GetString(5);
                }

            }

            return user;
        }

        //Inicio de sesión: Se le pase como parámetro el nombre del usuario y la contraseña,
        //buscar en la base de datos si el usuario existe y si coincide con la contraseña lo devuelve(el objeto Usuario), 
        //caso contrario devuelve uno vacío(Con sus datos vacíos y el id en 0)

        public static User LogIn(string username, string password)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from Usuario where NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", connection);
                command.Parameters.AddWithValue("@NombreUsuario", username);
                command.Parameters.AddWithValue("@Contraseña", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    reader.Read();
                    user.Id = reader.GetInt64(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.Username = reader.GetString(3);
                    user.Password = reader.GetString(4);
                    user.Mail = reader.GetString(5);
                }
            }

                return user;
        }

    }
}
