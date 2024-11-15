using DotLiquid.Tags;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Order : Transaction
    {
        public int CustomerID { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentMethodID { get; set; }
        public DateTime OverDueDate { get; set; }
        public DateTime? PaidAt { get; set; }
        public string DeliveryStatus { get; set; }
        public int ShippingProviderID { get; set; }

        public override void ProcessTransaction(SqlConnection connection)
        {
            string query = "INSERT INTO Orders (CustomerID, TotalAmount, OrderStatus, PaymentStatus, PaymentMethodID, OverDueDate, Paid_at, DeliveryStatus, ShippingProviderID) " +
                           "VALUES (@CustomerID, @TotalAmount, @OrderStatus, @PaymentStatus, @PaymentMethodID, @OverDueDate, @Paid_at, @DeliveryStatus, @ShippingProviderID)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                command.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
                command.Parameters.AddWithValue("@OverDueDate", OverDueDate);
                command.Parameters.AddWithValue("@Paid_at", PaidAt ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DeliveryStatus", DeliveryStatus);
                command.Parameters.AddWithValue("@ShippingProviderID", ShippingProviderID);

                command.ExecuteNonQuery();
            }
        }
    }

}
