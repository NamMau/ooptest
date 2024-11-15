using DotLiquid.Tags;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class ShoppingCart : Transaction 
    {
        public int CustomerID { get; set; }
        public List<CartProduct> Items { get; set; } = new List<CartProduct>();
    }
}

