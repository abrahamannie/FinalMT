using AssetManagementWebAPI.Model;
using AssetManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Repository
{
    public interface IUserRegRepository
    {
        Task<List<UserRegistration>> GetUsers();
        Task<int> AddUser(UserRegistration user);
        Task UpdateUser(UserRegistration user);
        Task<UserRegistration> DeleteUser(int id);
        Task<UserList> GetUserById(int id);
    }
}
