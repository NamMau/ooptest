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
            // Using the Singleton instance of TransactionStorage
            ITransactionStorage storage = TransactionStorage.Instance;

            Product product1 = new Product
            {
                ProductID = 1,
                Name = "Product A",
                Description = "Description of Product A",
                Price = 10.99,
                Stock = 100,
                CreatedAt = DateTime.Now,
                ShopID = 1
            };

            // Create new order then save
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

            // Saving the order transaction
            storage.SaveTransaction(newOrder);

            // Create new shopping cart then save
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

            // Saving the cart transaction
            storage.SaveTransaction(cart);
        }
    }
}

