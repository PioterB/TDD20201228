using System.Collections.Generic;
using VehiclesDiary.Tools.Persistence;

namespace VehicleDiary.Logic
{
    public interface IDiaryService
    {
        IEnumerable<DiaryItem> GetEvents(string vehicleName);
    }

    public class DiaryService : IDiaryService
    {
        public DiaryService(IRepository<string, DiaryItem> repository, IRepository<string, Car> carsRepoObject)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DiaryItem> GetEvents(string vehicleName)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(EventCreationRequest eventCreationRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}