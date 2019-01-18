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
      return _db.Query<Keep>("SELECT * FROM burger WHERE private = false");
    }



    // get keep by keep id
    public Keep GetKeepById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keep WHERE id = @id", new { id });
    }


    public Keep AddKeep(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keep(name, description, private, userId, img, views, shares, keeps) Values (@Name, @Description, @Private, @UserId @Img, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID()", keep);
      if (id == 0) return null;
      keep.Id = id;
      return keep;
    }



    public bool DeleteKeep(int id)
    {
      _db.Execute("Delete FROM Keep WHERE ID = @Id", new { ID = id });
      return true;
    }




  }
}