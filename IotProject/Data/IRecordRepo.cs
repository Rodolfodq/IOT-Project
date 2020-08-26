using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
