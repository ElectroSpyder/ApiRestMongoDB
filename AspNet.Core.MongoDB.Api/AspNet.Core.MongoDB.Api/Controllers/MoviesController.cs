using AspNet.Core.MongoDB.Models;
using AspNet.Core.MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Core.MongoDB.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MongoDBService _dbService;

        public MoviesController(MongoDBService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<List<Users>> Get() => await _dbService.GetMoviesAsync(); 
       

    }
}
