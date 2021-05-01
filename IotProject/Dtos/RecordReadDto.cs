using System;

namespace IotProject.Dtos
{
    public class RecordReadDto
    {
        
        public int RecordId { get; set; }        
        public DateTime RecordDateTime { get; set; }        
        public double RecordValue { get; set; }
        public int SensorId { get; set; }        
        public string Unit { get; set; }
    }
}
