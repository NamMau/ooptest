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
        private static TransactionStorage _instance;
        private static readonly object _lock = new object();

        private const string ConnectionString = @"Data Source=WINDOWS\SQLEXPRESS; Initial Catalog=shoptest; Integrated Security=True; Encrypt=False; TrustServerCertificate=True";

        // Private constructor to prevent instantiation
        private TransactionStorage() { }

        // Singleton property to get the instance
        public static TransactionStorage Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new TransactionStorage();
                    }
                    return _instance;
                }
            }
        }

        public void SaveTransaction(Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // Call method ProcessTransaction of object
                transaction.ProcessTransaction(connection);
                Console.WriteLine($"{transaction.GetType().Name} saved successfully.");
            }
        }
    }
}

