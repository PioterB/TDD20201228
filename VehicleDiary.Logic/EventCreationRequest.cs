using System;
using VehiclesDiary.Tools;

namespace VehicleDiary.Logic
{
    public class EventCreationRequest
    {
        public Car Owner { get; }

        public int Mileage { get; }

        public DateTime Timestamp { get; }

        protected EventCreationRequest(Car owner, int mileage, DateTime dateTime)
        {
            Owner = owner;
            Mileage = mileage;
            Timestamp = dateTime;
        }

        public static Result<EventCreationRequest> CreateValid(Car owner, int mileage, DateTime dateTime)
        {
            if (owner == null)
            {
                return Result<EventCreationRequest>.Failure();
            }

            if (mileage < 1)
            {
                return Result<EventCreationRequest>.Failure();
            }

            if (dateTime == default(DateTime))
            {
                return Result<EventCreationRequest>.Failure();
            }

            return new EventCreationRequest(owner, mileage, dateTime);
        }
    }
}