using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace VehiclesDiary.Controllers
{
    public class EventCreation
    {
        [Required]
        public string Timestamp { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Mileage { get; set; }

        [Required]
        public string VehicleName { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }
    }
}