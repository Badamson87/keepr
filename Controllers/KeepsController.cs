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
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _keepRepo;


    public KeepsController(KeepRepository keepRepo)
    {
      _keepRepo = keepRepo;
    }



    // get all keeps that are not private
    [HttpGet]
    public IEnumerable<Keep> GetAllKeeps()
    {
      return _keepRepo.GetAllKeeps();
    }



    //get all keeps by user id
    [Authorize]
    [HttpGet("{all}")]

    public ActionResult<IEnumerable<Keep>> GetKeepsByUserId()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> result = _keepRepo.GetAllKeepByUserId(userId);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }



    // put request to increase view keeps and save counts

    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep keep)
    {
      Keep result = _keepRepo.EditKeep(id, keep);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }





    //get single keep by id
    [HttpGet("{id}")]
    public ActionResult<Keep> GetAction(int id)
    {
      Keep result = _keepRepo.GetKeepById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();

    }



    // add a keep
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep keep)
    {
      keep.UserId = HttpContext.User.Identity.Name;
      return Created("/api/keeps", _keepRepo.AddKeep(keep));
    }


    // delete a keep

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Keep> Delete(int id)
    {
      var CurrentUserId = HttpContext.User.Identity.Name;
      if (_keepRepo.DeleteKeep(CurrentUserId, id))
      {
        return Ok("Success");
      }
      return NotFound("No keep found");
    }











  }
}
