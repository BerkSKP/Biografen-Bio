using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biografen.Models
{
    public class Movie
    {
        public int movieID { get; set; }
        public string movieName { get; set; }
        public double movietime { get; set; }
        public List<Movie> movieList { get; set; }
       // public Byte[] img { get; set; }
        public string img { get; set; }
    }
}
