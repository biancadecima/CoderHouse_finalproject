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
        //LogIn: The user name and password are passed as parameters, search the database if the user exists and if it matches the password it returns it.
        public static User LogIn(string username, string password)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select * from Usuario where NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", connection);
                command.Parameters.AddWithValue("@NombreUsuario", username);
                command.Parameters.AddWithValue("@Contraseña", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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

        //GetUser: It must receive a user's name in the URL, look it up in the database and return a User object.

        public static User GetUser(string username)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select * from Usuario where NombreUsuario = @username", connection);
                command.Parameters.AddWithValue("@username", username);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
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
        /*CreateUser: Receives a User-type json and must immediately register the user in the database*/
        public static void InsertUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) values (@name, @surname, @username, @password, @mail)", connection);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@mail", user.Mail);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        /*ModifyUser: All user data will be received by a json and it must be modified with the new data (Do not create a new one).*/
        public static void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
        /*DeleteUser: Receives the ID of the user to delete in the URL and must delete it from the database.*/
        public static void DeleteUser(long id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                List<Product> userProducts = ProductHandler.GetUsersProducts(id);
                foreach(Product product in userProducts)
                {
                    ProductHandler.DeleteProduct(product.Id);
                }
                SaleHandler.DeleteSale(id);

                SqlCommand command = new SqlCommand("delete from Usuario where Id = @id", connection);
                const string ParameterName = "@id";
                command.Parameters.AddWithValue(ParameterName, id);
                connection.Open();

                command.ExecuteNonQuery();
                
            }
        }
    }
}
