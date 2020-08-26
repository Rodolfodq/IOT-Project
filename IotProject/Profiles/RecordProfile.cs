using AutoMapper;
using IotProject.Dtos;
using IotProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Profiles
{
    public class RecordProfile: Profile
    {
        public RecordProfile()
        {
            CreateMap<Record, RecordReadDto>();
            CreateMap<RecordCreateDto, Record>();
            CreateMap<RecordUpdateDto, Record>();
            CreateMap<Record, RecordUpdateDto>();
        }
    }
}
