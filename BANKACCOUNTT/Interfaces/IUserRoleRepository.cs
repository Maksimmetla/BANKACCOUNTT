﻿using BANKACCOUNTT.Models;

namespace BANKACCOUNTT.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetAllAsync();
        Task<UserRole?> GetByIdAsync(int id);
        Task<UserRole> CreateUserRoleAsync(UserRole userRole);
        Task<bool> DeleteUserRoleAsync(int id);
        Task<UserRole?> UpdateUserRoleAsync(int id, UserRole userRole);
    }
}
