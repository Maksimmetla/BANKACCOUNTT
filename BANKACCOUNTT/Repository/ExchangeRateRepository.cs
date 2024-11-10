using BANKACCOUNTT.Data;
using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.EntityFrameworkCore;

namespace BANKACCOUNTT.Repository
{
    
    
      public class ExchangeRateRepository : IExchangeRateRepository
           {
            private readonly BankaccounttContext _context;
            public ExchangeRateRepository(BankaccounttContext context)
            {
                _context = context;
            }
            public async Task<ExchangeRate> CreateExchangeRateAsync(ExchangeRate exchangeRate)
            {
                await _context.ExchangeRates.AddAsync(exchangeRate);
                await _context.SaveChangesAsync();
                return exchangeRate;
            }
            public async Task<bool> DeleteExchangeRateAsync(int id)
        {
                var deletedEntry = await _context.ExchangeRates.FirstOrDefaultAsync(c =>
               c.Id == id);
                if (deletedEntry == null)
                {
                    return false;
                }
                _context.ExchangeRates.Remove(deletedEntry);
                await _context.SaveChangesAsync();
                return true;
            }
            public async Task<List<ExchangeRate>> GetAllAsync()
            {
                return await _context.ExchangeRates.ToListAsync();
            }
            public async Task<ExchangeRate?> GetByIdAsync(int id)
            {
                return await _context.ExchangeRates.FirstOrDefaultAsync(t => t.Id == id);
            }
            public async Task<ExchangeRate?> UpdateExchangeRateAsync(int id, ExchangeRate exchangeRate)
            {
                var ExitingExchangeRate = await _context.ExchangeRates.FirstOrDefaultAsync(c =>
               c.Id == id);
                if (ExitingExchangeRate == null)
                {
                    return null;
                }
                ExitingExchangeRate.Id = id;
                ExitingExchangeRate.Name = exchangeRate.Name;
                ExitingExchangeRate.Price = exchangeRate.Price;
                await _context.SaveChangesAsync();
                return ExitingExchangeRate;
            }
        }

    
}
