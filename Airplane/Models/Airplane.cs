using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneCore.Models
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Passengers { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
