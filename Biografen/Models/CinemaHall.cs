using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biografen.Models
{
    public class CinemaHall
    {
        public int cinemahallId { get; set; }
        // public int administratorId { get; set; }
        public int seats { get; set; }
        public int rows { get; set; }
        public string movieName { get; set; }
        public double movietime { get; set; }

    }
}
