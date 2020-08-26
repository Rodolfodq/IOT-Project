using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Models
{
    public class Device
    {
        
        [Required]
        public int DeviceId { get; set; }
        [Required]
        [MaxLength(20)]
        public string DeviceMacId { get; set; }
        [Required]
        [MaxLength(60)]
        public string DeviceName { get; set; }
        [Required]
        [MaxLength(60)]
        public string DeviceModel { get; set; }
        [Required]
        [MaxLength(60)]
        public string DeviceLocation { get; set; }        
        [Required]
        public string UserId { get; set; }
        
    }
}
