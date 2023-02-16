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

        public static void DeleteProductSaleBySaleID(long saleId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("delete from ProductoVendido where IdVenta = @saleId", connection);
                const string ParameterName = "@saleId";
                command.Parameters.AddWithValue(ParameterName, saleId);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        //Traer ProductosVendidos: Traer Todos los productos vendidos de un Usuario.Devuelve un Lista de objetos ProductoVendido.
        public static List<ProductSale> GetUsersSoldProducts(long userId)
        {
            List<ProductSale> usersSoldProducts = new List<ProductSale>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT ProductoVendido.Id, ProductoVendido.Stock, ProductoVendido.IdProducto, ProductoVendido.IdVenta from ProductoVendido inner join Producto ON ProductoVendido.IdProducto = Producto.Id where IdUsuario = @IdUsuario", connection);
                const string ParameterName = "@IdUsuario";
                command.Parameters.AddWithValue(ParameterName, userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductSale productSale = new ProductSale();
                        productSale.Id = reader.GetInt64(0);
                        productSale.Stock = reader.GetInt32(1);
                        productSale.ProductId = reader.GetInt64(2);
                        productSale.SaleId = reader.GetInt64(3);

                        usersSoldProducts.Add(productSale);
                    }
                }
            }

            return usersSoldProducts;
        }

    }
}
