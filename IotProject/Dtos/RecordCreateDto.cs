using System;
using System.ComponentModel.DataAnnotations;

namespace IotProject.Dtos
{
    public class RecordCreateDto
    {
        [Required]
        public DateTime RecordDateTime { get; set; }
        [Required]        
        public double RecordValue { get; set; }
        [Required]
        public int SensorId { get; set; }
        [Required]
        [MaxLength(6)]
        public string Unit { get; set; }

    }
}
