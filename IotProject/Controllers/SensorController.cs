using AutoMapper;
using IotProject.Data;
using IotProject.Dtos;
using IotProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IotProject.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorRepo _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDeviceRepo _deviceRepo;

        public SensorController(ISensorRepo repository, IMapper mapper, UserManager<IdentityUser> userManager, IDeviceRepo deviceRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _deviceRepo = deviceRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SensorReadDto>> GetAllSensors()
        {
            string userId = GetIdUser();
            var sensorItens = _repository.GetAllSensors();            
            List<Sensor> listSensor = new List<Sensor>();
            var deviceModelFromRepo = _deviceRepo.GetAllDevices(userId);            
            foreach (var sensorItem in sensorItens)
            {
                foreach (var deviceItem in deviceModelFromRepo)
                {                    
                    if(sensorItem.DeviceId == deviceItem.DeviceId)
                    {
                        listSensor.Add(sensorItem);
                    }
                }               

            }
            return Ok(_mapper.Map<IEnumerable<SensorReadDto>>(listSensor));            
                     
        }

        [HttpGet("id/{id}")]
        public ActionResult<SensorReadDto> GetSensorById(int id)
        {
            var sensorItem = _repository.GetSensorById(id);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(sensorItem.DeviceId);
            string userId = GetIdUser();
            if (sensorItem == null)
            {
                return NotFound();

            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            
            return Ok(_mapper.Map<SensorReadDto>(sensorItem));
        }

        [HttpGet("deviceidsensor/{id}", Name = "GetSensorByDeviceId")]
        public ActionResult<SensorReadDto> GetSensorByDeviceId(int id)
        {
            string userId = GetIdUser();
            IEnumerable<Sensor> sensorList = _repository.GetSensorByDeviceId(id);            
            
            if (sensorList == null)
            {
                return NotFound();
            }            
            return Ok(_mapper.Map<IEnumerable<SensorReadDto>>(sensorList));
        }

        [HttpGet("sensortoken/{sensorToken}")]
        public ActionResult<SensorReadDto> GetSensorByToken(string sensorToken)
        {
            var devicesSensores = _repository.GetSensorByToken(sensorToken);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(devicesSensores.DeviceId);
            string userId = GetIdUser();            
            if (devicesSensores == null)
            {
                return NotFound();
                
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }

            return Ok(_mapper.Map<SensorReadDto>(devicesSensores));
        }

        //Post api/sensor
        [HttpPost]
        public ActionResult<SensorReadDto> CreateSensor(SensorCreateDto sensorCreateDto)
        {
            if(sensorCreateDto == null)
            {
                return BadRequest();
            }
            sensorCreateDto.SensorToken = GenerateSensorToken();
            var sensorModel = _mapper.Map<Sensor>(sensorCreateDto);
            _repository.CreateSensor(sensorModel);
            _repository.SaveChanges();

            var sensorReadDto = _mapper.Map<SensorReadDto>(sensorModel);            
            return CreatedAtRoute(nameof(GetSensorByDeviceId), new { Id = sensorReadDto.SensorId }, sensorReadDto);
        }

        //PUT api/sensor/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSensor(int id, SensorUpdateDto sensorUpdateDto)
        {
            var sensorModelFromRepo = _repository.GetSensorById(id);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(sensorModelFromRepo.DeviceId);
            string userId = GetIdUser();
            
            if (sensorModelFromRepo == null)
            {
                return NotFound();
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }

            _mapper.Map(sensorUpdateDto, sensorModelFromRepo);
            _repository.UpdateSensor(sensorModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/sensor/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialSensorUpdate(int id, JsonPatchDocument<SensorUpdateDto> pathDoc)
        {
            var sensorModelFromRepo = _repository.GetSensorById(id);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(sensorModelFromRepo.DeviceId);
            string userId = GetIdUser();
            if (sensorModelFromRepo == null)
            {
                return NotFound();
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            var sensorToPatch = _mapper.Map<SensorUpdateDto>(sensorModelFromRepo);
            pathDoc.ApplyTo(sensorToPatch, ModelState);
            if (!TryValidateModel(sensorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(sensorToPatch, sensorModelFromRepo);            
            _repository.UpdateSensor(sensorModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //delete api/sensor/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSensor(int id)
        {
            var sensorModelFromRepo = _repository.GetSensorById(id);
            var deviceModelFromRepo = _deviceRepo.GetDeviceById(sensorModelFromRepo.DeviceId);
            string userId = GetIdUser();
            if (sensorModelFromRepo == null)
            {
                return NotFound();
            }
            else if(userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            _repository.DeleteSensor(sensorModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }


        private string GenerateSensorToken()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var sensorToken = new String(stringChars);
            return sensorToken;
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