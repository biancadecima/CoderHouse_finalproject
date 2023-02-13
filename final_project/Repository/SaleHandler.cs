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
        public static long InsertSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("insert into Venta(Comentarios, IdUsuario) values (@comentarios, @idUsuario); select @@identity", connection);
                command.Parameters.AddWithValue("@comentarios", sale.Comments);
                command.Parameters.AddWithValue("@idUsuario", sale.UserId);
                connection.Open();

                return Convert.ToInt64(command.ExecuteScalar());
            }
        }

        /*Cargar Venta: Recibe una lista de productos y el numero de IdUsuario de quien la efectuó, primero cargar una nueva venta en la base de datos, 
        luego debe cargar los productos recibidos en la base de ProductosVendidos uno por uno por un lado, y descontar el stock en la base de productos por el otro.*/
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
        
        //Traer Ventas: Recibe como parámetro un IdUsuario, debe traer todas las ventas de la base asignados al usuario particular.
        public static List<Sale> GetUserSale(long userId)
        {
            List<Sale> userSales = new List<Sale>();
            using (SqlConnection connection = new SqlConnection(connectionString))
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
    }
}
