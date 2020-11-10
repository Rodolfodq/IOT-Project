using System.ComponentModel.DataAnnotations;

namespace IotProject.Dtos
{
    public class DeviceCreateDto
    {
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
        //[Required]
        public string UserId { get; set; }
        public int FgAtivo = 1;
    }
}
