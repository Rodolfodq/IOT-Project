using System.ComponentModel.DataAnnotations;

namespace IotProject.Dtos
{
    public class SensorUpdateDto
    {
        [Required]
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
        [Required]
        [MaxLength(8)]
        public string SensorToken { get; set; }
    }
}
