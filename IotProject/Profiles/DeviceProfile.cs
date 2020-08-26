using AutoMapper;
using IotProject.Dtos;
using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceReadDto>();
            CreateMap<DeviceCreateDto, Device>();
            CreateMap<DeviceUpdateDto, Device>();
            CreateMap<Device, DeviceUpdateDto>();
        }
    }
}
