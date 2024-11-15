using AngleSharp.Dom;
using Microsoft.Graph;
using OfficeDevPnP.Core.Diagnostics.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
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
                ID = 1,
                CustomerID = 123,
                TotalAmount = 250.50,
                OrderStatus = "Pending",
                PaymentStatus = "Unpaid",
                PaymentMethodID = 2,
                OverDueDate = DateTime.Now.AddDays(7),
                CreatedAt = DateTime.Now
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

            storage.SaveTransaction(cart);
        } 
    }
}
