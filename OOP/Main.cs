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

            // create Order và save
            Order newOrder = new Order
            {
                ID = 2,
                CustomerID = 2,
                TotalAmount = 50.00,
                OrderStatus = "Completed",
                PaymentStatus = "Unpaid",
                PaymentMethodID = 2,
                OverDueDate = DateTime.Now.AddDays(7),
                PaidAt = DateTime.Now,
                DeliveryStatus = "Shipped",
                ShippingProviderID = 2,
            };

            storage.SaveTransaction(newOrder);

            // create ShoppingCart và save
            ShoppingCart cart = new ShoppingCart
            {
                ID = 3,
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
