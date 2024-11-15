using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class TransactionStorage : ITransactionStorage
    {
        private const string V = @"Data Source= WINDOWS\SQLEXPRESS; Initial Catalog = shopping; Integrated Security = True; Encrypt = False;TrustServerCertificate=True";

        private string _connectionString = V;


        public void SaveTransaction(Transaction transaction)
        {
            if (transaction is Order order)
            {
                SaveOrder(order);
                Console.WriteLine("Saving Order to the database.");

            }
            else if (transaction is ShoppingCart cart)
            {
                // Simulate saving the ShoppingCart to the database
                SaveShoppingCart(cart);
                Console.WriteLine("Saving ShoppingCart to the database.");

            }
            else
            {
                throw new ArgumentException("Unknown transaction type.");
            }
        }

        private void SaveOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(V))
            {
                connection.Open();

                string query = "INSERT INTO Order_tb (CustomerID, TotalAmount, OrderStatus, PaymentStatus, PaymentMethodID, OverDueDate) " +
                               "VALUES (@CustomerID, @TotalAmount, @OrderStatus, @PaymentStatus, @PaymentMethodID, @OverDueDate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                command.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
                command.Parameters.AddWithValue("@PaymentStatus", order.PaymentStatus);
                command.Parameters.AddWithValue("@PaymentMethodID", order.PaymentMethodID);
                command.Parameters.AddWithValue("@OverDueDate", order.OverDueDate);
                command.ExecuteNonQuery();

                Console.WriteLine("Order saved successfully.");
            }
        }




        private void SaveShoppingCart(ShoppingCart cart)
        {
            using (SqlConnection connection = new SqlConnection(V))
            {
                string query = "INSERT INTO Carts (CartID, CustomerID, TotalAmount, CreatedAt) " +
                               "VALUES (@CartID, @CustomerID, @TotalAmount, @CreatedAt)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CartID", cart.ID);
                command.Parameters.AddWithValue("@CustomerID", cart.CustomerID);
                command.Parameters.AddWithValue("@TotalAmount", cart.TotalAmount);
                command.Parameters.AddWithValue("@CreatedAt", cart.CreatedAt);

                connection.Open();
                command.ExecuteNonQuery();

                // Save Cart Items
                foreach (var item in cart.Items)
                {
                    string itemQuery = "INSERT INTO ShoppingCart (CartID, ProductID, Quantity) " +
                                       "VALUES (@CartID, @ProductID, @Quantity)";

                    SqlCommand itemCommand = new SqlCommand(itemQuery, connection);
                    itemCommand.Parameters.AddWithValue("@CartID", cart.ID);
                    itemCommand.Parameters.AddWithValue("@ProductID", item.ProductID);
                    itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);

                    itemCommand.ExecuteNonQuery();
                }

                Console.WriteLine("Shopping cart saved successfully.");
            }
        }
    }
}
