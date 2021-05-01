using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Models
{
    public class Record
    {
        [Required]
        public int RecordId { get; set; }
        [Required]
        public DateTime RecordDateTime { get; set; }
        [Required]        
        public double RecordValue { get; set; }        
        public int SensorId { get; set; }
        [Required]
        [MaxLength(6)]
        public string Unit { get; set; }
    }
}
