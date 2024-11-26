using Microsoft.EntityFrameworkCore;
using ServicesLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Repositories
{
    public class TransactionRepository : ITransactionRepository 
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transaction t)
        {
            _context.Transactions.Add(t);
            _context.SaveChanges();
        }

        public void UpdateTransaction(Transaction t)
        {
            _context.Transactions.Update(t);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int transactionId)
        {
            var t = _context.Transactions.Find(transactionId);
            if (t != null)
            {
                _context.Transactions.Remove(t);
                _context.SaveChanges();
            }
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return _context.Transactions.Include(t => t.BankAccount).FirstOrDefault(t => t.Id == transactionId);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(t => t.BankAccount).ToList();
        }





    }
}
