using System;

namespace VehicleDiary.Logic
{
    public class DiaryItem
    {
        public Car Car { get; }

        public int Mileage { get; }

        public DateTime DateTime { get; }

        public DiaryItem(Car car, in int mileage, DateTime dateTime)
        {
            if (dateTime > DateTime.Now)
            {
                throw new InvalidOperationException("must be from past");
            }

            if (mileage <= 0)
            {
                throw new InvalidOperationException("must be positive");
            }

            Car = car;
            Mileage = mileage;
            DateTime = dateTime;
        }
    }
}