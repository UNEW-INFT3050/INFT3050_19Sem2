using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week8_InterstellarTravel.Models
{
    public class CustomerQuery
    {
        public const string SESSION_KEY = "CustomerQuery";
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}