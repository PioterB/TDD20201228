using System;
using VehicleDiary.Logic;

namespace VehiclesDiary.Controllers
{
    public class DiaryEvent 
    {
        public DiaryEvent(DiaryItem item)
        {
            throw new NotImplementedException();
        }

        public DateTimeOffset Timestamp { get; }

        public VehiclePreview Vehicle { get; }

        public int Mileage { get; }

        public string Comment { get; }
    }
}