using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biografen.Models
{
    public class Billings
    {
        public int billingsId { get; set; }
        public long cardNumber { get; set; }
        public string cardName { get; set; }
        public int seatChoice { get; set; }
        public string movieName { get; set; }
        public DateTime Date { get; set; }
        public double time { get; set; }
    }
}
