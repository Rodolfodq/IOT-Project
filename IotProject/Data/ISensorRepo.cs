using IotProject.Models;
using System.Collections.Generic;

namespace IotProject.Data
{
    public interface ISensorRepo
    {
        bool SaveChanges();

        IEnumerable<Sensor> GetAllSensors();
        Sensor GetSensorById(int id);

        IEnumerable<Sensor> GetSensorByDeviceId(int id);

        void CreateSensor(Sensor sensor);

        Sensor GetSensorByToken(string sensorToken);

        void UpdateSensor(Sensor sensor);

        void DeleteSensor(Sensor sensor);

    }
}
