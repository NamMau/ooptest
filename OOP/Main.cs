using AngleSharp.Dom;
using Microsoft.Graph;
using OfficeDevPnP.Core.Diagnostics.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            
            ITransactionStorage storage = new TransactionStorage();

            // Create an order and save it
            Order newOrder = new Order
            {
                ID = 2,
                CustomerID = 2,
                TotalAmount = 50,
                OrderStatus = "Completed",
                PaymentStatus = "Unpaid",
                PaymentMethodID = 2,
                OverDueDate = DateTime.Now.AddDays(7),
                PaidAt = DateTime.Now,
                delivery_status = "Shipped",
                ShippingProviderID = 2,
            };

            storage.SaveTransaction(newOrder);

            // Create a shopping cart and save it
            ShoppingCart cart = new ShoppingCart
            {
                ID = 2,
                CustomerID = 123,
                TotalAmount = 150.00,
                CreatedAt = DateTime.Now,
                Items = new List<CartProduct>
            {
                new CartProduct { ProductID = 1, Quantity = 2 },
                new CartProduct { ProductID = 2, Quantity = 1 }
            }
            };
            // Create instances of different transaction types
            Transaction credit = new CreditTransaction { ID = 1, TotalAmount = 100.0, CreatedAt = DateTime.Now };
            Transaction debit = new DebitTransaction { ID = 2, TotalAmount = 50.0, CreatedAt = DateTime.Now };

            // Using polymorphism to process different types of transactions
            ProcessTransaction(credit);
            ProcessTransaction(debit);

            public static void ProcessTransaction(Transaction transaction)
            {
            transaction.ProcessTransaction(); // Calls the overridden method in the specific subclass
            }

            storage.SaveTransaction(cart);
        } 
    }
}
