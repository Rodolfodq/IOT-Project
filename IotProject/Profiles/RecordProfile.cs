using AutoMapper;
using IotProject.Dtos;
using IotProject.Models;

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
