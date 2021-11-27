using AssetManagementWebAPI.Model;
using AssetManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Repository
{
    public interface IAssetMasterRepository
    {
        Task<List<AssetMaster>> GetAssetMasters();
        Task<int> AddAssetMaster(AssetMaster master);
        Task UpdateAssetMaster(AssetMaster master);
        Task<AssetMaster> DeleteAssetMaster(int id);
        Task<AssetMasterList> GetAssetMasterById(int id);
    }
}
