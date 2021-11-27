using AssetManagementWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Repository
{
    
    public class LoginRepository : ILoginRepository
    {
        AssetManagementDbContext db;

        public LoginRepository(AssetManagementDbContext _db)
        {
            db = _db;
        }

        #region Get User
        /*
        public Login GetUser(Login user)
        {
            if (db != null)
            {
                Login dbUser = db.Login.FirstOrDefault(em => em.Username == user.Username && em.Password == user.Password);
                if (dbUser != null)
                {
                    return dbUser;
                }
            }
            return null;
        }
        */
        #endregion

        #region GetUserByPassword
        public async Task<ActionResult<Login>> GetUserByPassword(string un, string pwd)
        {
            if (db != null)
            {
                Login user = await db.Login.FirstOrDefaultAsync(em => em.Username == un && em.Password == pwd);
                return user;
            }
            return null;
        }
        #endregion

        #region Validate User
        public Login validateUser(string Username, string Password)
        {
            if (db != null)
            {
                Login dbuser = db.Login.FirstOrDefault(em => em.Username == Username && em.Password == Password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;
        }
        #endregion

    }
}
