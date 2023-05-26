using AspNet.Core.MongoDB.Models;
using AspNet.Core.MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Core.MongoDB.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class CPresupuestoController : Controller
    {
        private readonly CPresupuestoService _dbService;
        public CPresupuestoController(CPresupuestoService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<List<CPresupuesto>> Get() => await _dbService.GetPresupuestoAsync();

        [HttpPost]
        public async Task Post(CPresupuesto cPresupuesto) => await _dbService.CreatePresupuestoAsync(cPresupuesto);
    }
}
