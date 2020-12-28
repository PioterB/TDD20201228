using System;
using System.ComponentModel.DataAnnotations;
using VehicleDiary.Logic;

namespace VehiclesDiary.Controllers
{
	public class VehicleCreationRequest
	{
		public VehicleCreationRequest()
		{
		}

		public string Make { get; set; }

		public string Model { get; set; }

		public DateTimeOffset Bought { get; set; }

		[Required]
		[StringLength(25, MinimumLength = 3)]
		public string Name { get; set; }

        public CarCreateRequest ToDomain()
        {
			return new CarCreateRequest(Name);
        }
    }
}