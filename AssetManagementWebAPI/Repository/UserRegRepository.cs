using AssetManagementWebAPI.Model;
using AssetManagementWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Repository
{
    public class UserRegRepository: IUserRegRepository
    {
        AssetManagementDbContext db;
        public UserRegRepository(AssetManagementDbContext _db)
        {
            db = _db;
        }

        #region Get Users
        // Get all the users from UserRegistration Table
        public async Task<List<UserRegistration>> GetUsers()
        {
            if (db != null)
            {
                return await db.UserRegistration.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Users
        //Add a new User to the UserRegistration Table
        public async Task<int> AddUser(UserRegistration user)
        {
            if (db != null)
            {
                await db.UserRegistration.AddAsync(user);
                await db.SaveChangesAsync();
                return (int)user.UId;
            }
            return 0;
        }
        #endregion

        #region Update User
        //to update a user in UserRegistration Table
        public async Task UpdateUser(UserRegistration user)
        {
            if (db != null)
            {
                db.UserRegistration.Update(user);
                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete User
        //Delete a user from UserRegistration Table
        public async Task<UserRegistration> DeleteUser(int id)
        {
            if (db != null)
            {
                UserRegistration dbuser = db.UserRegistration.Find(id);
                db.UserRegistration.Remove(dbuser);
                await db.SaveChangesAsync();
                return (dbuser);
            }
            return null;
        }
        #endregion

        #region GetUserById
        //Get user by id
        public async Task<UserList> GetUserById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join UserRegistration and Login
                return await(from u in db.UserRegistration
                             from l in db.Login
                             where u.UId == id && u.UId == l.LId
                             select new UserList
                             {
                                 UId=u.UId,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 Age=u.Age,
                                 Gender=u.Gender,
                                 Username=l.Username,
                                 Password=l.Password,
                                 UserType=l.UserType

                             }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

    }
}
