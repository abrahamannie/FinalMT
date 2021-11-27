using AssetManagementWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Repository
{
    public interface ILoginRepository
    {
        //public Login GetUser(Login user);
        Task<ActionResult<Login>> GetUserByPassword(string un, string pwd);
        public Login validateUser(string Username, string Password);
    }
}
