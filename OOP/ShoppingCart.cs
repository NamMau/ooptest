using DotLiquid.Tags;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class ShoppingCart : Transaction
    {
        public int CustomerID { get; set; }
        public List<CartProduct> Items { get; set; } = new List<CartProduct>();

        public override void ProcessTransaction(SqlConnection connection)
        {
            string query = "INSERT INTO Carts (CartID, CustomerID, TotalAmount, CreatedAt) " +
                           "VALUES (@CartID, @CustomerID, @TotalAmount, @CreatedAt)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CartID", ID);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

                command.ExecuteNonQuery();
            }

            // Save Cart Items
            foreach (var item in Items)
            {
                string itemQuery = "INSERT INTO ShoppingCartItems (CartID, ProductID, Quantity) " +
                                   "VALUES (@CartID, @ProductID, @Quantity)";

                using (SqlCommand itemCommand = new SqlCommand(itemQuery, connection))
                {
                    itemCommand.Parameters.AddWithValue("@CartID", ID);
                    itemCommand.Parameters.AddWithValue("@ProductID", item.ProductID);
                    itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);

                    itemCommand.ExecuteNonQuery();
                }
            }
        }
    }
}

