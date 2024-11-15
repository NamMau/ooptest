using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class TransactionStorage : ITransactionStorage
    {
        private const string ConnectionString = @"Data Source=WINDOWS\SQLEXPRESS; Initial Catalog=shoptest; Integrated Security=True; Encrypt=False; TrustServerCertificate=True";

        public void SaveTransaction(Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // call method ProcessTransaction of the passed object
                transaction.ProcessTransaction(connection);
                Console.WriteLine($"{transaction.GetType().Name} saved successfully.");
            }
        }
    }
}
