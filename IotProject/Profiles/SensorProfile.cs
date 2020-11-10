using AutoMapper;
using IotProject.Dtos;
using IotProject.Models;

namespace IotProject.Profiles
{
    public class SensorProfile: Profile
    {
        public SensorProfile()
        {
            //Source - target
            CreateMap<Sensor, SensorReadDto>();
            CreateMap<SensorCreateDto, Sensor>();
            CreateMap<SensorUpdateDto, Sensor>();
            CreateMap<Sensor, SensorUpdateDto>();
        }
    }
}
