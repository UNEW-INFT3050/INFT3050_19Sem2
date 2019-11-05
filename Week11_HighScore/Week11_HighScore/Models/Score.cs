using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week11_HighScore.Models
{
    // Represents a single score in a high score table
    public class ScoreRecord
    {
        public string Name { get; set; }
        public int Score { get; set; } 
    }
}