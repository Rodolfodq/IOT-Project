using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Dtos
{
    public class DeviceReadDto
    {
        
        public int DeviceId { get; set; }        
        public string DeviceMacId { get; set; }       
        public string DeviceName { get; set; }        
        public string DeviceModel { get; set; }        
        public string DeviceLocation { get; set; }      
        
    }
}
