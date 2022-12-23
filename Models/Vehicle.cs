using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMVC.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string CompanyName { get; set; }
        public string ModelName { get; set; }
        public int Power { get; set; }
    }
}
