using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleDiary.Logic;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IDiaryService _service;

        public EventsController(IDiaryService service, IRepository<string, Car> repoMockObject)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<DiaryEvent> Get(string vehicleName)
        {
            return _service.GetEvents(vehicleName)
                .Select(item => new DiaryEvent(item))
                .ToArray();
        }

        [HttpPost]
        public ObjectResult Create(EventCreation details)
        {
            throw new NotImplementedException();
        }
    }
}
