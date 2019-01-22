using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    //private readonly FakeDb _db;

    public readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }


    // get all keeps
    public IEnumerable<Keep> GetAllKeeps()
    {
      // think i will have to address this function not sure how to write the private part
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isprivate = 0");
    }

    public IEnumerable<Keep> GetAllKeepByUserId(string userId)
    {
      return _db.Query<Keep>($"SELECT * FROM Keeps WHERE userId = @userId", new { userId });
    }


    // Edit a keep

    public Keep EditKeep(int id, Keep newKeep)
    {
      newKeep.Id = id;
      try
      {
        return _db.QueryFirstOrDefault<Keep>($@"
     UPDATE Keep SET
      Views = @Views,
      Shares = @Shares,
      Keeps = @Keeps,
      WHERE Id = {id};
      SELECT * FROM Keeps WHERE Id = {id};", newKeep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }



    // get keep by keep id
    public Keep GetKeepById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keep WHERE id = @id", new { id });
    }


    public Keep AddKeep(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps(name, description, UserId, isPrivate, img, views, shares, keeps)
       VALUES (@Name, @Description, @UserId, @IsPrivate, @Img, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID()", keep);
      if (id == 0) return null;
      keep.Id = id;
      return keep;
    }



    public bool DeleteKeep(string UserId, int id)
    {

      _db.Execute("Delete FROM Keep WHERE ID = @Id AND UserId = @UserId", new { ID = id, UserId });
      return true;
    }




  }
}