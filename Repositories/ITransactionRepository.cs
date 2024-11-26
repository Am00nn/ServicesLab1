using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLab1.Models;


namespace ServicesLab1.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();

        Transaction GetTransactionById(int transactionId);

        void AddTransaction(Transaction transaction);

        void UpdateTransaction(Transaction transaction);

        void DeleteTransaction(int transactionId);

   



    }
}
