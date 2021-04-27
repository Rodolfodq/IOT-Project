using AutoMapper;
using IotProject.Data;
using IotProject.Dtos;
using IotProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IotProject.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordRepo _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDeviceRepo _deviceRepo;
        private readonly ISensorRepo _sensorRepo;

        public RecordController(IRecordRepo repository, IMapper mapper, UserManager<IdentityUser> userManager, IDeviceRepo deviceRepo, ISensorRepo sensorRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _deviceRepo = deviceRepo;
            _sensorRepo = sensorRepo;

        }

        [HttpPost]
        public ActionResult<RecordReadDto> CreateRecord(List<RecordCreateDto> recordsCreateDto)
        {
            foreach (RecordCreateDto recordCreateDto in recordsCreateDto)
            {
                if (recordCreateDto == null)
                {
                    return BadRequest();
                }
                var recordModel = _mapper.Map<Record>(recordCreateDto);
                _repository.RecordCreate(recordModel);
                _repository.SaveChanges();

                //var recordReadDto = _mapper.Map<RecordReadDto>(recordModel);
                
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult<RecordReadDto> CreateRecord(RecordCreateDto recordCreateDto)
        {
            if (recordCreateDto == null)
            {
                return BadRequest();
            }
            var recordModel = _mapper.Map<Record>(recordCreateDto);
            _repository.RecordCreate(recordModel);
            _repository.SaveChanges();

            //var recordReadDto = _mapper.Map<RecordReadDto>(recordModel);
            return Ok();
        }
    }
}