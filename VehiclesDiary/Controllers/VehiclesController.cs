using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VehicleDiary.Logic;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesService _service;
        private readonly IRepository<string, Car> _repo;

        public VehiclesController(IVehiclesService service, IRepository<string, Car> repo)
        {
            _service = service;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<VehiclePreview> Get()
        {
            return (_repo.GetAll() ?? Enumerable.Empty<Car>())
                .Select(car => new VehiclePreview(car))
                .ToArray();
        }

        [HttpPost]
        public IActionResult Add(VehicleCreationRequest input)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IStatusCodeActionResult Del(string name)
        {
            throw new NotImplementedException();
        }
    }
}