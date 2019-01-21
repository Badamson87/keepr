using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;


namespace keepr.Repositories
{

  public class VaultRepository
  {

    public readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }



    //Add a vault

    public Vault AddVault(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults(name, description, userId) 
      Values(@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID()", vault);
      if (id == 0) return null;
      vault.Id = id;
      return vault;
    }



    // get all vaults by user id

    public IEnumerable<Vault> GetAllVaultsByUserId(string userId)
    {
      return _db.Query<Vault>($"SELECT * FROM Vaults WHERE userId = @userId", new { userId });
    }




    // Get a vault by id

    public Vault GetVaultById(int id)
    {
      // if the get by vault does not work double check the s on from vaults
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id = @id", new { id });
    }



    // Delete a vault

    public bool DeleteVault(string UserId, int id)
    {
      // same thing here i think the s on vaults are right here but i think it needs one in keeps
      _db.Execute("DELETE FROM vaults WHERE ID = @Id AND UserId = @UserId", new { ID = id, UserId });
      return true;
    }



  }
}