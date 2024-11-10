using BANKACCOUNTT.Models;

namespace BANKACCOUNTT.Interfaces
{
    public interface IExchangeRateRepository
    {
        Task<List<ExchangeRate>> GetAllAsync();
        Task<ExchangeRate?> GetByIdAsync(int id);
        Task<ExchangeRate> CreateExchangeRateAsync(ExchangeRate exchangeRate);
        Task<bool> DeleteExchangeRateAsync(int id);
        Task<ExchangeRate?> UpdateExchangeRateAsync(int id, ExchangeRate exchangeRate);
    }
}
