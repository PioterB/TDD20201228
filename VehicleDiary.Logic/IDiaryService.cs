using System.Collections.Generic;

namespace VehicleDiary.Logic
{
    public interface IDiaryService
    {
        IEnumerable<DiaryItem> GetEvents(string vehicleName);
    }

    public class DiaryService : IDiaryService
    {
        public IEnumerable<DiaryItem> GetEvents(string vehicleName)
        {
            throw new System.NotImplementedException();
        }
    }
}