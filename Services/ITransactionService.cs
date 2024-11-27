using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLab1.Models;

namespace ServicesLab1.Services
{
    public interface ITransactionService
    {

        void AddTransaction(Transaction transaction);

        void UpdateTransaction(Transaction transaction);

        void DeleteTransaction(int T_Id);

        Transaction GetTransactionById(int T_Id);

        IEnumerable<Transaction> GetAllTransactions();
    }
}
