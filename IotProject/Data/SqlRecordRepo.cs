using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Data
{
    public class SqlRecordRepo:IRecordRepo
    {
        private readonly AppDBContext _context;

        public SqlRecordRepo(AppDBContext context)
        {
            _context = context;
        }

        public void DeleteRecord(Record record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
            _context.Record.Remove(record);
        }

        public IEnumerable<Record> GetAllRecords()
        {
            return _context.Record.ToList();
        }

        public Record GetRecordById(int id)
        {
            return _context.Record.FirstOrDefault(p => p.RecordId == id);
        }

        public Record GetRecordBySensor(int idSensor)
        {
            return _context.Record.FirstOrDefault(p => p.SensorId == idSensor);
        }

        public void RecordCreate(Record record)
        {
            if(record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
            _context.Add(record);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRecord(Record record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
            _context.Update(record);
        }
    }
}
