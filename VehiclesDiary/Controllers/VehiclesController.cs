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
        public VehiclesController(IVehiclesService service, IRepository<string, Car> repo)
        {

        }

        [HttpGet]
        public IEnumerable<VehiclePreview> Get()
        {
            throw new NotImplementedException();
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