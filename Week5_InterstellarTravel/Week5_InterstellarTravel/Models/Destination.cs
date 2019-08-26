using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week5_InterstellarTravel.Models
{
    /// <summary>
    /// A travel destination
    /// </summary>
    public class Destination
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public long DistanceInKm { get; set; }
    }
}