using BANKACCOUNTT.Data;
using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.EntityFrameworkCore;

namespace BANKACCOUNTT.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly BankaccounttContext _context;
        public TransactionHistoryRepository(BankaccounttContext context)
        {
            _context = context;
        }
        public async Task<TransactionHistory> CreateTransactionHistoryAsync(TransactionHistory transactionHistory)
        {
            await _context.TransactionHistories.AddAsync(transactionHistory);
            await _context.SaveChangesAsync();
            return transactionHistory;
        }
        public async Task<bool> DeleteTransactionHistoryAsync(int id)
        {
            var deletedEntry = await _context.TransactionHistories.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }
            _context.TransactionHistories.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<TransactionHistory>> GetAllAsync()
        {
            return await _context.TransactionHistories.ToListAsync();
        }
        public async Task<TransactionHistory?> GetByIdAsync(int id)
        {
            return await _context.TransactionHistories.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<TransactionHistory?> UpdateTransactionHistoryAsync(int id, TransactionHistory transactionHistory)
        {
            var ExitingTransactionHistory = await _context.TransactionHistories.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (ExitingTransactionHistory == null)
            {
                return null;
            }
            ExitingTransactionHistory.Id = id;
            ExitingTransactionHistory.RecipientCard = transactionHistory.RecipientCard;
            ExitingTransactionHistory.SendCard = transactionHistory.SendCard;
            ExitingTransactionHistory.Transaction = transactionHistory.Transaction;
            ExitingTransactionHistory.SendCardId = transactionHistory.SendCardId;
            ExitingTransactionHistory.RecipientCardId = transactionHistory.RecipientCardId;
            ExitingTransactionHistory.SunOfMoney = transactionHistory.SunOfMoney;
            ExitingTransactionHistory.DatetimeDearture = transactionHistory.DatetimeDearture;
            ExitingTransactionHistory.TransactionId = transactionHistory.TransactionId;
            ExitingTransactionHistory.RecipientCard = transactionHistory.RecipientCard;
            await _context.SaveChangesAsync();
            return ExitingTransactionHistory;
        }
    }
}
