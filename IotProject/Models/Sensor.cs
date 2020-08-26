using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Models
{
    public class Sensor
    {
        [Required]
        public int SensorId { get; set; }
        [MaxLength(60)]
        public string SensorName { get; set; }
        [Required]
        [MaxLength(60)]
        public string SensorModel { get; set; }
        [Required]
        [MaxLength(60)]
        public string SensorFunction { get; set; }        
        [Required]
        public int DeviceId { get; set; }         
        [MaxLength(8)]
        public string SensorToken { get; set; }

    }
}
