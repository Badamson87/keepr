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

    public bool DeleteVaultKeeps(string userId, int id)
    {
      _db.Execute("DELETE FROM vaultkeeps WHERE id = @Id AND userId = @UserId", new { userId, id, });
      return true;
    }


    // get Keeps by vault id

    public IEnumerable<Keep> GetAllKeepsByVaultId(string userId, int vaultId)
    {
      return _db.Query<Keep>($"SELECT * FROM vaultkeeps WHERE vaultId = @vaultId  AND userId = @userId", new { userId, vaultId });
    }







  }

}