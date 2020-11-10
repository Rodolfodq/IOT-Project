using IotProject.Models;
using System.Collections.Generic;

namespace IotProject.Data
{
    public interface IDeviceRepo
    {
        IEnumerable<Device> GetAllDevices();
        Device GetDeviceById(int id);
        Device GetDeviceByMac(string macId);
        void CreateDevice(Device device);
        bool SaveChanges();
        void UpdateDevice(Device device);

        void DeleteDevice(Device device);
    }
}
