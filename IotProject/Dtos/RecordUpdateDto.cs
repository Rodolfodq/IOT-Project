using System;
using System.ComponentModel.DataAnnotations;

namespace IotProject.Dtos
{
    public class RecordUpdateDto
    {
        [Required]
        public DateTime RecordDateTime { get; set; }
        [Required]
        [MaxLength(50)]
        public string RecordValue { get; set; }
        [Required]
        public int SensorId { get; set; }
        [Required]
        [MaxLength(6)]
        public string Unit { get; set; }
    }
}
