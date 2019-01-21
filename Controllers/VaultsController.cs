using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _vaultRepo;


    public VaultsController(VaultRepository vaultRepo)
    {
      _vaultRepo = vaultRepo;
    }


    // get vaults by user id



    // add a vault
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault vault)
    {
      vault.UserId = HttpContext.User.Identity.Name;
      return Created("/api/vaults", _vaultRepo.AddVault(vault));
    }



    // delete a vault
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Vault> Delete(int id)
    {
      var CurrentUserId = HttpContext.User.Identity.Name;
      if (_vaultRepo.DeleteVault(CurrentUserId, id))
      {
        return Ok("success");
      }
      return NotFound("No Vault Found");
    }





  }


}