using DotLiquid.Tags;
using System;
using System.Collections.Generic;
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
    }

}
