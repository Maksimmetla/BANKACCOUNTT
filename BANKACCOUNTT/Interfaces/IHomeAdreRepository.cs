using BANKACCOUNTT.Models;

namespace BANKACCOUNTT.Interfaces
{
    public interface IHomeAdreRepository
    {
        Task<List<HomeAdre>> GetAllAsync();
        Task<HomeAdre?> GetByIdAsync(int id);
        Task<HomeAdre> CreateHomeAdreAsync(HomeAdre homeAdre);
        Task<bool> DeleteHomeAdreAsync(int id);
        Task<HomeAdre?> UpdateHomeAdreAsync(int id, HomeAdre homeAdre);
    }
}
