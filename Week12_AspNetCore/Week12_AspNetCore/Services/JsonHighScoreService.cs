using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;


namespace Week12_AspNetCore.Services
{
    public class JsonHighScoreService
    {
        public JsonHighScoreService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public Models.HighScoreTable m_storedScores = new Models.HighScoreTable(10, 10000, 1000);
        public Models.HighScoreTable HighScores { get { return m_storedScores; } }
    }
}
