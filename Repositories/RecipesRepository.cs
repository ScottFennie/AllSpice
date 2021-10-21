using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

    internal List<Recipe> GetAll()
    {
     string sql = "SELECT * FROM recipes";
     return _db.Query<Recipe>(sql).ToList();
    }

     internal Recipe Post(Recipe recipeData)
    {
      string sql = @"
      INSERT INTO recipes(creatorId, instructions)
      VALUES(@CreatorId, @Instructions);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }
    }
}