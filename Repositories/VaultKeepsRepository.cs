using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {

    public readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }



    // add a keep by vault id

    public VaultKeeps AddVaultKeeps(VaultKeeps vaultKeeps)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultKeeps(vaultId, keepId, userId)
      VALUES(@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();", vaultKeeps);
      if (id == 0) return null;
      vaultKeeps.Id = id;
      return vaultKeeps;

    }



    // Delete a keep by vault id

    public bool DeleteVaultKeeps(VaultKeeps payload)
    {
      _db.Execute("DELETE FROM vaultKeeps WHERE keepId = @KeepId AND vaultId = @VaultId AND userId = @UserId", payload);
      return true;
    }


    // get Keeps by vault id

    public IEnumerable<Keep> GetAllKeepsByVaultId(string userId, int vaultId)
    {
      return _db.Query<Keep>($@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId) 
      ", new { userId, vaultId });
    }







  }

}