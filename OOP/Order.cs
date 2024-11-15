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
        internal string delivery_status;

        public int CustomerID { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime OverDueDate { get; set; }
        public DateTime? PaidAt { get; set; }
        public string DeliveryStatus { get; set; }
        public int ShippingProviderID { get; set; }
        public int Paid_at { get; internal set; }
        public int PaymentMethodID { get; internal set; }
    }

}
