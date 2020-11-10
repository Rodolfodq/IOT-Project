namespace IotProject.Dtos
{
    public class SensorReadDto
    {
        public int SensorId { get; set; }
        public string SensorName { get; set; }        
        public string SensorModel { get; set; }        
        public string SensorFunction { get; set; }        
        public int DeviceId { get; set; }        
        public string SensorToken { get; set; }
    }
}
