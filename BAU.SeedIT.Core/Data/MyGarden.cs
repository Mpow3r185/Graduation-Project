using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bau.Seedit.Core.Data
{
    public class MyGarden
    {
        [Key]
        public int PlantId { get; set; }
        public string CommonName { get; set; }
        public string Categories { get; set; }
        public string Origin { get; set; }
        public string Climat { get; set; }
        public string TemperatureMax { get; set; }
        public string TemperatureMin { get; set; }
        public string Watering { get; set; }
        public string Color { get; set; }
        public string PotDiameter { get; set; }
        public string Use_ { get; set; }
    }
}
