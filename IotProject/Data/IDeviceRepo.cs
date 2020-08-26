using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
