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



    // Delete a keep by vault it


    // get Keeps by vault id




  }
}