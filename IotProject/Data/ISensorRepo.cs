using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Data
{
    public interface ISensorRepo
    {
        bool SaveChanges();

        IEnumerable<Sensor> GetAllSensors();
        Sensor GetSensorById(int id);

        Sensor GetSensorByDeviceId(int id);

        void CreateSensor(Sensor sensor);

        Sensor GetSensorByToken(string sensorToken);

        void UpdateSensor(Sensor sensor);

        void DeleteSensor(Sensor sensor);

    }
}
