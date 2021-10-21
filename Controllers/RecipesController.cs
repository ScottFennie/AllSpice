using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
        _recipesService = recipesService;
    }

    
    [HttpGet]

    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
           return Ok(_recipesService.GetAll());
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]

    public async Task<ActionResult<Recipe>> Post([FromBody] Recipe recipeData)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          // for node reference - req.body.creatorId = req.userInfo.id
          // FIXME NEVER TRUST THE CLIENT
          recipeData.CreatorId = userInfo.Id;
          Recipe createdRecipe = _recipesService.Post(recipeData);
          createdRecipe.Creator = userInfo;
          return createdRecipe;
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }



    }

    
}