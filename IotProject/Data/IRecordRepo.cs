using IotProject.Models;
using System.Collections.Generic;

namespace IotProject.Data
{
    public interface IRecordRepo
    {
        IEnumerable<Record> GetAllRecords();
        Record GetRecordById(int id);        
        Record GetRecordBySensor(int idSensor);

        public bool SaveChanges();

        void RecordCreate(Record record);

        void UpdateRecord(Record record);

        void DeleteRecord(Record record);
    }
}
