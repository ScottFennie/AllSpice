using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class RecipesService
    {

        private readonly RecipesRepository _recipesRepository;

        public RecipesService(RecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }
    public List<Recipe> GetAll()
    {
      return _recipesRepository.GetAll();
    }

      public Recipe Post(Recipe recipeData)
    {
      return _recipesRepository.Post(recipeData);
    }
    }
}