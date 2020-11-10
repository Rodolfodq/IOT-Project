using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            sensor.FgAtivo = 0;
            _context.Update(sensor);
            //_context.Sensor.Remove(sensor);
        }

        public IEnumerable<Sensor> GetAllSensors()
        {
            return _context.Sensor.Where(p => p.FgAtivo == 1).ToList();
        }

        public IEnumerable<Sensor> GetSensorByDeviceId(int id)
        {
            return _context.Sensor.Where(p => p.DeviceId == id && p.FgAtivo == 1).ToList();
        }

        public Sensor GetSensorById(int id)
        {
            return _context.Sensor.FirstOrDefault(p => p.SensorId == id && p.FgAtivo == 1);
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
