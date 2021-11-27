using AssetManagementWebAPI.Model;
using AssetManagementWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Repository
{
    public class AssetMasterRepository:IAssetMasterRepository
    {
        AssetManagementDbContext db;
        public AssetMasterRepository(AssetManagementDbContext _db)
        {
            db = _db;
        }

        #region Get AssetMaster
        public async Task<List<AssetMaster>> GetAssetMasters()
        {
            if (db != null)
            {
                return await db.AssetMaster.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add AssetMaster
        public async Task<int> AddAssetMaster(AssetMaster master)
        {
            if (db != null)
            {
                await db.AssetMaster.AddAsync(master);
                await db.SaveChangesAsync();
                return master.AmId;
            }
            return 0;
        }
        #endregion

        #region Update AssetMaster
        public async Task UpdateAssetMaster(AssetMaster master)
        {
            if (db != null)
            {
                db.AssetMaster.Update(master);
                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete AssetMaster
        public async Task<AssetMaster> DeleteAssetMaster(int id)
        {
            if (db != null)
            {
                AssetMaster dbmaster = db.AssetMaster.Find(id);
                db.AssetMaster.Remove(dbmaster);
                await db.SaveChangesAsync();
                return (dbmaster);
            }
            return null;
        }
        #endregion

        #region GetAssetMasterById
        public async  Task<AssetMasterList> GetAssetMasterById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join AssetMaster and Purchase Order
                return await (from a in db.AssetMaster
                              from v in db.Vendor
                              from p in db.PurchaseOrder
                              where a.AmId == id && a.AmMakeId == p.PdVendorId
                              select new AssetMasterList
                              {
                                  AmId = a.AmId,
                                  PdOrderNo = p.PdOrderNo,
                                  AmModel = a.AmModel,
                                  AmSnumber = a.AmSnumber,
                                  AmMyyear = a.AmMyyear,
                                  AmPdate = a.AmPdate,
                                  AmWaranty = a.AmWaranty,
                                  AmForm=a.AmForm,
                                  AmTo=a.AmTo,
                                  PdDate=p.PdDate,
                                  PdDdate=p.PdDdate,
                                  PdStatus=p.PdStatus

                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
        
    }
}
