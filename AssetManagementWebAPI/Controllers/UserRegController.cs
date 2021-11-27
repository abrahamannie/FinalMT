using AssetManagementWebAPI.Models;
using AssetManagementWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegController : ControllerBase
    {
        IUserRegRepository UserRegRepository;
        public UserRegController(IUserRegRepository _u)
        {
            UserRegRepository = _u;
        }

        #region GetUsers

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await UserRegRepository.GetUsers();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddUser()

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UserId = await UserRegRepository.AddUser(model);
                    if (UserId > 0)
                    {
                        return Ok(UserId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region UpdateUser()

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await UserRegRepository.UpdateUser(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        #endregion

        #region DeleteUser()

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await UserRegRepository.DeleteUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region GetUserById

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await UserRegRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
