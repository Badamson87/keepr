using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace keepr.Models
{

  public class Vault
  {
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }


    [Required]
    public string UserId { get; set; }

    // public bool IsPrivate { get; set; }






  }
}