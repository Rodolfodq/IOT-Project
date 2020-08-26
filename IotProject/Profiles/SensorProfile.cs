using IotProject.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IotProject.Dtos;

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
