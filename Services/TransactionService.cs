using ServicesLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServicesLab1.Models;
using ServicesLab1.Repositories;

namespace ServicesLab1.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }


        public void AddTransaction(Transaction t)
        {

            _transactionRepository.AddTransaction(t);

        }

        public void UpdateTransaction(Transaction t)
        {
            _transactionRepository.UpdateTransaction(t);
        }

        public void DeleteTransaction(int T_ID)
        {

            _transactionRepository.DeleteTransaction(T_ID);


        }


        public Transaction GetTransactionById(int T_ID)

        {

            return _transactionRepository.GetTransactionById(T_ID);




        }

        public IEnumerable<Transaction> GetAllTransactions()
        {


            return _transactionRepository.GetAllTransactions();


        }







    }
}
