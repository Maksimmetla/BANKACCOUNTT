using BANKACCOUNTT.Models;

namespace BANKACCOUNTT.Interfaces
{
    public interface ITransactionTypeRepository
    {
        Task<List<TransactionType>> GetAllAsync();
        Task<TransactionType?> GetByIdAsync(int id);
        Task<TransactionType> CreateTransactionTypeAsync(TransactionType transactionType);
        Task<bool> DeleteTransactionTypeAsync(int id);
        Task<TransactionType?> UpdateTransactionTypeAsync(int id, TransactionType transactionType);
    }
}
