using BANKACCOUNTT.Data;
using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.EntityFrameworkCore;

namespace BANKACCOUNTT.Repository
{
    public class HomeAdreRepository : IHomeAdreRepository
    {
        
            private readonly BankaccounttContext _context;
        public HomeAdreRepository(BankaccounttContext context)
        {
            _context = context;
        }
        public async Task<HomeAdre> CreateHomeAdreAsync(HomeAdre homeAdre)
        {
            await _context.HomeAdres.AddAsync(homeAdre);
            await _context.SaveChangesAsync();
            return homeAdre;
        }
        public async Task<bool> DeleteHomeAdreAsync(int id)
        {
            var deletedEntry = await _context.HomeAdres.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }
            _context.HomeAdres.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<HomeAdre>> GetAllAsync()
        {
            return await _context.HomeAdres.ToListAsync();
        }
        public async Task<HomeAdre?> GetByIdAsync(int id)
        {
            return await _context.HomeAdres.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<HomeAdre?> UpdateHomeAdreAsync(int id, HomeAdre homeAdre)
        {
            var ExitingHomeAdre = await _context.HomeAdres.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (ExitingHomeAdre == null)
            {
                return null;
            }
            ExitingHomeAdre.Id = id;
            ExitingHomeAdre.Users = homeAdre.Users;
            ExitingHomeAdre.Country = homeAdre.Country;
            ExitingHomeAdre.City = homeAdre.City;
            ExitingHomeAdre.Adres = homeAdre.Adres;
            ExitingHomeAdre.Home = homeAdre.Home;
            ExitingHomeAdre.Apartment = homeAdre.Apartment;
            await _context.SaveChangesAsync();
            return ExitingHomeAdre;
        }
    }
}
