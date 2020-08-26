using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IotProject.Data;
using IotProject.Dtos;
using IotProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IotProject.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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

        //get api/records
        [HttpGet]
        public ActionResult<IEnumerable<RecordReadDto>> GetAllRecords()
        {
            string userId = GetIdUser();
            var recordItens = _repository.GetAllRecords();
            List<Record> listRecord = new List<Record>();
            var deviceModelFromRepo = _deviceRepo.GetAllDevices();
            deviceModelFromRepo = deviceModelFromRepo.Where(u => u.UserId == userId).ToList();
            var sensorModelFromRepo = _sensorRepo.GetAllSensors();
            foreach(var recordItem in recordItens)
            {
                foreach(var sensorItem in sensorModelFromRepo)
                {
                    foreach(var deviceItem in deviceModelFromRepo)
                    {
                        if(recordItem.SensorId == sensorItem.SensorId && sensorItem.DeviceId == deviceItem.DeviceId)
                        {
                            listRecord.Add(recordItem);
                        }
                    }
                }
            }

            return Ok(_mapper.Map<IEnumerable<RecordReadDto>>(listRecord));
        }

        //get api/record/5
        [HttpGet("id/{id}", Name = "GetRecordById")]
        public ActionResult<RecordReadDto> GetRecordById(int id)
        {
            var recordItem = _repository.GetRecordById(id);
            var devicesSensores = _sensorRepo.GetSensorById(recordItem.SensorId);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(devicesSensores.DeviceId);
            string userId = GetIdUser();
            if (recordItem != null)
            {
                return NotFound();                
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            return Ok(_mapper.Map<RecordReadDto>(recordItem));

        }

        //get api/sensorId/5
        [HttpGet("sensorId/{idSensor}")]
        public ActionResult<RecordReadDto> GetRecordBySensor(int idSensor)
        {            
            var sensorId = _repository.GetRecordBySensor(idSensor);
            var devicesSensores = _sensorRepo.GetSensorById(idSensor);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(devicesSensores.DeviceId);
            string userId = GetIdUser();
            if (sensorId != null)
            {
                return NotFound();
                
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            return Ok(_mapper.Map<RecordReadDto>(sensorId));
        }

        [HttpPost]
        public ActionResult<RecordReadDto> CreateRecord(RecordCreateDto recordCreateDto)
        {
            if(recordCreateDto == null)
            {
                return BadRequest();
            }
            var recordModel = _mapper.Map<Record>(recordCreateDto);
            _repository.RecordCreate(recordModel);
            _repository.SaveChanges();

            var recordReadDto = _mapper.Map<RecordReadDto>(recordModel);
            return CreatedAtRoute(nameof(GetRecordById), new { Id = recordReadDto.RecordId }, recordReadDto);
        }

        //PUT api/record/id
        [HttpPut("{id}")]
        public ActionResult RecordUpdate(int id, RecordUpdateDto recordUpdateDto)
        {
            var recordModelFromRepo = _repository.GetRecordById(id);
            var sensorModelFromRepo = _sensorRepo.GetSensorById(recordModelFromRepo.SensorId);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(sensorModelFromRepo.DeviceId);
            string userId = GetIdUser();
            if (recordModelFromRepo == null)
            {
                return NotFound();
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }

            _mapper.Map(recordUpdateDto, recordModelFromRepo);
            _repository.UpdateRecord(recordModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/record/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialRecordUpdate(int id, JsonPatchDocument<RecordUpdateDto> pathDoc)
        {
            var recordModelFromRepo = _repository.GetRecordById(id);
            var sensorModelFromRepo = _sensorRepo.GetSensorById(recordModelFromRepo.SensorId);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(sensorModelFromRepo.DeviceId);
            string userId = GetIdUser();
            if (recordModelFromRepo == null)
            {
                return NotFound();
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            var recordToPatch = _mapper.Map<RecordUpdateDto>(recordModelFromRepo);
            pathDoc.ApplyTo(recordToPatch, ModelState);
            if (!TryValidateModel(recordToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(recordToPatch, recordModelFromRepo);
            _repository.UpdateRecord(recordModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //delete api/record/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRecord(int id)
        {
            var recordModelFromRepo = _repository.GetRecordById(id);

            var sensorModelFromRepo = _sensorRepo.GetSensorById(recordModelFromRepo.SensorId);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(sensorModelFromRepo.DeviceId);
            string userId = GetIdUser();

            if (recordModelFromRepo == null)
            {
                return NotFound();
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            _repository.DeleteRecord(recordModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
              
        }

        private string GetIdUser()
        {
            string email = User.Identity.Name.ToString();
            var userRecord = _userManager.FindByEmailAsync(email.ToUpper());
            var userId = userRecord.Result.Id.ToString();
            return userId;

        }
    }
}