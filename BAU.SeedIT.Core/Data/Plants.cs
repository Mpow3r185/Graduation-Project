using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bau.Seedit.Core.Data
{
    public class Plants
    {
        [Key]
        public int id { get; set; }
        public string commonName { get; set; }
        public string botanicalName { get; set; }
        public string plantType { get; set; }
        public string size { get; set; }
        public string soilType { get; set; }
        public string soilPH { get; set; }
        public string hardinessZones { get; set; }
        public string nativeArea { get; set; }
        public string image { get; set; }
        public string site { get; set; }
        public string matureSize { get; set; }
        public string bloomTime { get; set; }
        public string flowerColor { get; set; }
        public string toxicity { get; set; }
        public string family { get; set; }
        public string sunExposure { get; set; }

    }
}
