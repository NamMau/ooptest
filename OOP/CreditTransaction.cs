using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP{
    public class CreditTransaction : Transaction
    {
        public override void ProcessTransaction()
        {
            Console.WriteLine($"Processing Credit Transaction with ID {ID} and amount {TotalAmount}");
        }
    }
}