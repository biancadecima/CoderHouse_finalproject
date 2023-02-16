using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    internal class ProductHandler : SqlHandler
    {
        public static void InsertProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("insert into Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) values (@description, @cost, @salePrice, @stock, @userId)", connection);
                command.Parameters.AddWithValue("@description", product.Descriptions);
                command.Parameters.AddWithValue("@cost", product.Cost);
                command.Parameters.AddWithValue("@salePrice", product.SalePrice);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.Parameters.AddWithValue("@userId", product.UserId);
                command.Parameters.AddWithValue("@id", product.Id);
                connection.Open();

                command.ExecuteNonQuery();
            }

        }

        public static int UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("update Producto set Descripciones = @description, Costo = @cost, PrecioVenta = @salePrice, Stock = @stock, IdUsuario = @userId  where Id = @id", connection);
                command.Parameters.AddWithValue("@description", product.Descriptions);
                command.Parameters.AddWithValue("@cost", product.Cost);
                command.Parameters.AddWithValue("@salePrice", product.SalePrice);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.Parameters.AddWithValue("@userId", product.UserId);
                command.Parameters.AddWithValue("@id", product.Id);
                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static int UpdateProductStock(long id, int saleAmount)
        {
            Product product = GetProduct(id);
            product.Stock -= saleAmount;
            return UpdateProduct(product);
        }

        public static void DeleteProduct(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ProductSaleHandler.DeleteProductSale(id);
                SqlCommand command = new SqlCommand("delete from Producto where Id = @id", connection);
                const string ParameterName = "@id";
                command.Parameters.AddWithValue(ParameterName, id);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        //Traer Productos: Recibe un número de IdUsuario como parámetro,
        //debe traer todos los productos cargados en la base de este usuario en particular.
        public static List<Product> GetUsersProducts(long userId)
        {
            List<Product> usersProducts = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from Producto where IdUsuario = @idUsuario", connection);
                const string ParameterName = "@idUsuario";
                command.Parameters.AddWithValue(ParameterName, userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Product product = new Product();
                        product.Id = reader.GetInt64(0);
                        product.Descriptions = reader.GetString(1);
                        product.Cost = reader.GetDecimal(2);
                        product.SalePrice = reader.GetDecimal(3);
                        product.Stock = reader.GetInt32(4);
                        product.UserId = reader.GetInt64(5);

                        usersProducts.Add(product);
                    }
                }

                return usersProducts;
            }
        }

        public static Product GetProduct(long Id)
        {
            Product product = new Product();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from Producto where Id = @Id", connection);
                const string ParameterName = "@Id";
                command.Parameters.AddWithValue(ParameterName, Id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt64(0);
                        product.Descriptions = reader.GetString(1);
                        product.Cost = reader.GetDecimal(2);
                        product.SalePrice = reader.GetDecimal(3);
                        product.Stock = reader.GetInt32(4);
                        product.UserId = reader.GetInt64(5);

                    }
                }

                return product;
            }
        }
    }
}
