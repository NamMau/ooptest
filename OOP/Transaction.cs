using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Transaction
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public double TotalAmount { get; set; }
    
    // interface method
    public abstract void ProcessTransaction(SqlConnection connection);
    }
}
