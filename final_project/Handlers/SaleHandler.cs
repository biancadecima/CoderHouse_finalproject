using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class SaleHandler : SqlHandler
    {
        //GetSales: You must bring all the sales of the base that a User has made. It receives the User id as a URL parameter and returns a list of Sale objects.
        public static List<Sale> GetUserSale(long userId)
        {
            List<Sale> userSales = new List<Sale>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select * from Venta where IdUsuario = @idUsuario", connection);
                const string ParameterName = "@idUsuario";
                command.Parameters.AddWithValue(ParameterName, userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sale sale = new Sale();
                        sale.Id = reader.GetInt64(0);
                        sale.Comments = reader.GetString(1);
                        sale.UserId = reader.GetInt64(2);

                        userSales.Add(sale);
                    }
                }

                return userSales;
            }
        }
        /*InsertSale: creates a sale*/
        public static long InsertSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into Venta(Comentarios, IdUsuario) values (@comentarios, @idUsuario); select @@identity", connection);
                command.Parameters.AddWithValue("@comentarios", sale.Comments);
                command.Parameters.AddWithValue("@idUsuario", sale.UserId);
                connection.Open();

                return Convert.ToInt64(command.ExecuteScalar());
            }
        }

        /*LoadSale: Receives a list of products and the UserID number of the person who made it, first load a new sale in the database,
         * then load the received products in the ProductSold base one by one on one side, and discount the stock in the product base on the other.*/
        public static void LoadSale(long idUser, List<Product> soldProducts)
        {
            Sale sale = new Sale();
            sale.UserId = idUser;
            sale.Comments = "Venta realizada";
            long idSale = InsertSale(sale);
            foreach(Product product in soldProducts)
            {
                ProductSale newSoldProduct = new ProductSale();
                newSoldProduct.Stock = product.Stock;
                newSoldProduct.ProductId = product.Id;
                newSoldProduct.SaleId = idSale;
                ProductSaleHandler.InsertProductSale(newSoldProduct);
                ProductHandler.UpdateProductStock(product.Id, 1);
            }
        }

        public static void DeleteSale(long userId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                List<Sale> userSales = GetUserSale(userId);
                foreach(Sale sale in userSales)
                {
                    ProductSaleHandler.DeleteProductSaleBySaleID(sale.Id);
                }

 
                SqlCommand command = new SqlCommand("delete from Venta where IdUsuario = @id", connection);
                const string ParameterName = "@id";
                command.Parameters.AddWithValue(ParameterName, userId);
                connection.Open();

                command.ExecuteNonQuery();

            }

        }

    }
}
