using AutoMapper;
using IotProject.Dtos;
using IotProject.Models;

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
