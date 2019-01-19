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

    public IEnumerable<Keep> Keeps { get; set; }


    public KeepsController(KeepRepository keepRepo)
    {
      _keepRepo = keepRepo;
    }



    // get all keeps that are not private
    [HttpGet]

    public IEnumerable<Keep> GetKeeps()
    {
      return _keepRepo.GetAllKeeps();
    }



    //get all keeps by user id





    // get all keeps by vault id


    // put request to increase view keeps and save counts




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

    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep keep)
    {
      keep.UserId = HttpContext.User.Identity.Name;
      return Created("/api/keeps", _keepRepo.AddKeep(keep));
    }


    // delete a keep


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
