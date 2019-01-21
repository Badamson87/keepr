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


  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkRepo;

    public VaultKeepsController(VaultKeepsRepository vkRepo)
    {
      _vkRepo = vkRepo;
    }


    // add a keep by vault id
    [Authorize]
    [HttpPost]

    public ActionResult<VaultKeeps> Post([FromBody] VaultKeeps vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.Identity.Name;
      VaultKeeps result = _vkRepo.AddVaultKeeps(vaultKeep);
      return Created("/api/vaultKeeps/" + result.Id, result);
    }




    // Delete a vaultKeep
    [Authorize]
    [HttpDelete("{id}")]

    public ActionResult<VaultKeeps> Delete(int id)
    {
      string userId = HttpContext.User.Identity.Name;
      if (_vkRepo.DeleteVaultKeeps(userId, id))
      {
        return Ok("success");
      }
      return NotFound("No Keep FOund");

    }







    // get Keeps by vault id
    [Authorize]
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> vaultKeeps(int vaultId)
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> result = _vkRepo.GetAllKeepsByVaultId(UserId, vaultId);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }




  }
}