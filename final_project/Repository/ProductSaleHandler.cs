using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    internal class ProductSaleHandler : SqlHandler
    {

        public static void InsertProductSale(ProductSale soldProduct)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("insert into ProductoVendido (Stock, IdProducto, IdVenta) values (@stock, @productId, @saleId)", connection);
                command.Parameters.AddWithValue("@stock", soldProduct.Stock);
                command.Parameters.AddWithValue("@productId", soldProduct.ProductId);
                command.Parameters.AddWithValue("@saleId", soldProduct.SaleId);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteProductSale(long productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("delete from ProductoVendido where IdProducto = @productId", connection);
                const string ParameterName = "@productId";
                command.Parameters.AddWithValue(ParameterName, productId);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        //Traer ProductosVendidos: Traer Todos los productos vendidos de un Usuario, cuya información está en su producto
        //(Utilizar dentro de esta función el "Traer Productos" anteriormente hecho para saber que productosVendidos ir a buscar).

        public static List<Product> GetUsersSoldProducts(long userId)
        {
            List<Product> usersSoldProducts = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Producto.Descripciones FROM Producto inner join ProductoVendido ON ProductoVendido.IdProducto = Producto.Id where IdUsuario = @IdUsuario", connection);
                const string ParameterName = "@IdUsuario";
                command.Parameters.AddWithValue(ParameterName, userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = reader.GetInt64(0);
                        product.Descriptions = reader.GetString(1);
                        product.Cost = reader.GetDecimal(2);
                        product.SalePrice = reader.GetDecimal(3);
                        product.Stock = reader.GetInt32(4);
                        product.UserId = reader.GetInt64(5);

                        usersSoldProducts.Add(product);
                    }
                }
            }

            return usersSoldProducts;
        }

    }
}
