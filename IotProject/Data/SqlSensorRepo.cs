using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IotProject.Data
{
    public class SqlSensorRepo : ISensorRepo
    {
        private readonly AppDBContext _context;

        public SqlSensorRepo(AppDBContext context)
        {
            _context = context;
        }

        public void CreateSensor(Sensor sensor)
        {
            if(sensor == null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }

            _context.Add(sensor);
        }

        public void DeleteSensor(Sensor sensor)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }
            _context.Sensor.Remove(sensor);
        }

        public IEnumerable<Sensor> GetAllSensors()
        {
            return _context.Sensor.ToList();
        }

        public Sensor GetSensorByDeviceId(int id)
        {
            return _context.Sensor.FirstOrDefault(p => p.DeviceId == id);
        }

        public Sensor GetSensorById(int id)
        {
            return _context.Sensor.FirstOrDefault(p => p.SensorId == id);
        }

        public Sensor GetSensorByToken(string sensorToken)
        {
            return _context.Sensor.FirstOrDefault(p => p.SensorToken == sensorToken);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSensor(Sensor sensor)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }
            _context.Update(sensor);
        }
    }
}
