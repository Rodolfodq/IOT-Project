using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotProject.Dtos
{
    public class RecordReadDto
    {
        
        public int RecordId { get; set; }        
        public DateTime RecordDateTime { get; set; }        
        public string RecordValue { get; set; }
        public int SensorId { get; set; }        
        public string Unit { get; set; }
    }
}
