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
    public class AssetMasterController : ControllerBase
    {
        IAssetMasterRepository AssetMasterRepository;
        public AssetMasterController(IAssetMasterRepository _a)
        {
            AssetMasterRepository = _a;
        }

        #region GetAssetMasters

        [HttpGet]
        [Route("GetAssetMasters")]
        public async Task<IActionResult> GetAssetMasters()
        {
            try
            {
                var masters = await AssetMasterRepository.GetAssetMasters();
                if (masters == null)
                {
                    return NotFound();
                }
                return Ok(masters);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddAssetMaster

        [HttpPost]
        [Route("AddAssetMaster")]
        public async Task<IActionResult> AddAssetMaster([FromBody] AssetMaster model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MasterId = await AssetMasterRepository.AddAssetMaster(model);
                    if (MasterId > 0)
                    {
                        return Ok(MasterId);
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

        #region UpdateAssetMaster

        [HttpPut]
        [Route("UpdateAssetMaster")]
        public async Task<IActionResult> UpdateAssetMaster([FromBody] AssetMaster model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await AssetMasterRepository.UpdateAssetMaster(model);
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

        #region DeleteAssetMaster

        [HttpDelete]
        [Route("DeleteAssetMaster")]
        public async Task<IActionResult> DeleteAssetMaster(int id)
        {
            try
            {
                var master = await AssetMasterRepository.DeleteAssetMaster(id);
                if (master == null)
                {
                    return NotFound();
                }
                return Ok(master);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region GetAssetMasterById

        [HttpGet]
        [Route("GetAssetMasterById")]
        public async Task<IActionResult> GetAssetMasterById(int id)
        {
            try
            {
                var master = await AssetMasterRepository.GetAssetMasterById(id);
                if (master == null)
                {
                    return NotFound();
                }
                return Ok(master);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
