using IotProject.Models;
using System;
using System.Collections.Generic;

namespace IotProject.Data
{
    public class MockDeviceRepo : IDeviceRepo
    {
        public void CreateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public void DeleteDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetAllDevices()
        {
            var devices = new List<Device>
            {
                new Device { DeviceId = 0, DeviceMacId = "00:E0:4C:7E:02:E3", DeviceName = "Raspberry Pi", DeviceModel = "3 B+", DeviceLocation = "-21.1835996, -47.8367763" },
                new Device { DeviceId = 1, DeviceMacId = "00:E0:4C:07:C0:42", DeviceName = "Raspberry Pi", DeviceModel = "Zero", DeviceLocation = "-21.1835951, -47.8367751" },
                new Device { DeviceId = 2, DeviceMacId = "00:E0:4C:5F:2E:0A", DeviceName = "Raspberry Pi", DeviceModel = "3 B", DeviceLocation = "-21.1835978, -47.8367783" }
            };

            return devices;
        }

        public IEnumerable<Device> GetAllDevices(string userId)
        {
            throw new NotImplementedException();
        }

        public Device GetDeviceById(int id)
        {
            return new Device { DeviceId = 0, DeviceMacId = "00:E0:4C:7E:02:E3", DeviceName = "Raspberry Pi", DeviceModel = "3 B+", DeviceLocation = "-21.1835996, -47.8367763" };
        }

        public Device GetDeviceByMac(string macId)
        {
            return new Device { DeviceId = 0, DeviceMacId = "00:E0:4C:7E:02:E3", DeviceName = "Raspberry Pi", DeviceModel = "3 B+", DeviceLocation = "-21.1835996, -47.8367763" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateDevice(Device device)
        {
            throw new NotImplementedException();
        }
    }
}
