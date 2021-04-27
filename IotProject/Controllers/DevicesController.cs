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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]    
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepo _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public DevicesController(IDeviceRepo repository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager; 
        }       


        //get api/devices
        [HttpGet]
        public ActionResult<IEnumerable<DeviceReadDto>> GetAllDevices()
        {
            string userId = GetIdUser();
            IEnumerable<Device> deviceItens = _repository.GetAllDevices(userId);          
            //deviceItens = deviceItens.Where(u => u.UserId == userId).ToList();
            return Ok(_mapper.Map<IEnumerable<DeviceReadDto>>(deviceItens));
        }

        //get api/devices/id/{id}
        [HttpGet("id/{id}", Name = "GetDeviceById")]
        public ActionResult<DeviceReadDto> GetDeviceById(int id)
        {
            var deviceItem = _repository.GetDeviceById(id);
            string userId = GetIdUser();
            if(deviceItem == null)
            {
                return NotFound();
            }
            else if(userId != deviceItem.UserId)
            {
                return Unauthorized();
            }
            return Ok(_mapper.Map<DeviceReadDto>(deviceItem));           
            
        }

        [HttpGet("idmac/{macId}")]
        public ActionResult<DeviceReadDto> GetDeviceByMac(string macId)
        {
            var deviceItem = _repository.GetDeviceByMac(macId);
            string userId = GetIdUser();
            if (deviceItem == null)
            {
                return NotFound();                
            }
            else if (userId != deviceItem.UserId)
            {
                return Unauthorized();
            }
            return Ok(_mapper.Map<DeviceReadDto>(deviceItem));
        }

        [HttpPost]
        public ActionResult<DeviceReadDto> CreateDevice(DeviceCreateDto deviceCreateDto)
        {            
            string userId = GetIdUser();
            deviceCreateDto.UserId = userId;            

            if (deviceCreateDto == null)
            {
                return BadRequest();
            }

            var deviceModel = _mapper.Map<Device>(deviceCreateDto);

            _repository.CreateDevice(deviceModel);
            _repository.SaveChanges();

            var deviceReadDto = _mapper.Map<DeviceReadDto>(deviceModel);
            return CreatedAtRoute(nameof(GetDeviceById), new { Id = deviceReadDto.DeviceId }, deviceReadDto);            
        }

        [HttpPut("{id}")]
        public ActionResult DeviceUpdate(int id, DeviceUpdateDto deviceUpdateDto)
        {
            var deviceModelFromRepo = _repository.GetDeviceById(id);
            string userId = GetIdUser();
            if (deviceModelFromRepo == null)
            {
                return NotFound();
            }
            else if(userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
                        
            _mapper.Map(deviceUpdateDto, deviceModelFromRepo);
            deviceModelFromRepo.UserId = userId;
            _repository.UpdateDevice(deviceModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/device/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialRecordUpdate(int id, JsonPatchDocument<DeviceUpdateDto> pathDoc)
        {
            var deviceModelFromRepo = _repository.GetDeviceById(id);
            string userId = GetIdUser();
            if (deviceModelFromRepo == null)
            {
                return NotFound();
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            var deviceToPatch = _mapper.Map<DeviceUpdateDto>(deviceModelFromRepo);
            pathDoc.ApplyTo(deviceToPatch, ModelState);
            if (!TryValidateModel(deviceToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(deviceToPatch, deviceModelFromRepo);
            _repository.UpdateDevice(deviceModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //delete api/device/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDevice(int id)
        {
            var deviceModelFromRepo = _repository.GetDeviceById(id);
            string userId = GetIdUser();
            if (deviceModelFromRepo == null)
            {
                return NotFound();
            }
            else if (userId != deviceModelFromRepo.UserId)
            {
                return Unauthorized();
            }
            _repository.DeleteDevice(deviceModelFromRepo);
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
