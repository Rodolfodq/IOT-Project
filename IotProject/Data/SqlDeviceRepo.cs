using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IotProject.Data
{
    public class SqlDeviceRepo : IDeviceRepo
    {
        private readonly AppDBContext _context;

        public SqlDeviceRepo(AppDBContext context)
        {
            _context = context;
        }

        public void CreateDevice(Device device)
        {
            if(device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            _context.Add(device);
        }

        public void DeleteDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            device.FgAtivo = 0;
            _context.Update(device);            
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _context.Device.Where(p => p.FgAtivo == 1).ToList();
        }

        public Device GetDeviceById(int id)
        {
            return _context.Device.FirstOrDefault(p => p.DeviceId == id && p.FgAtivo == 1);
        }

        public Device GetDeviceByMac(string macId)
        {
            return _context.Device.FirstOrDefault(p => p.DeviceMacId == macId && p.FgAtivo == 1);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            _context.Update(device);
        }
    }
}
