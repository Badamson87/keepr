using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace keepr.Models
{

  public class Vaults
  {
    [Required]
    public string Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }


    [Required]
    internal string UserId { get; set; }

    public bool IsPrivate { get; set; }






  }
}