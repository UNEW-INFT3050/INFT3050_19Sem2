using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Week11_HighScore.Controllers
{
    public class ScoresController : ApiController
    {
        // data access 
        DataAccess.DBScore m_db;

        //
        // Constructor
        public ScoresController()
        {
            m_db = new DataAccess.DBScore();
        }

        /// <summary>
        /// get api/scores
        /// </summary>
        /// <returns></returns>
        public List<Models.ScoreRecord> GetScores()
        {
            return m_db.GetHighScores();
        }

        // POST(Insert): api/scores
        public void PostScore([FromBody]Models.ScoreRecord score)
        {
            m_db.AddNewScore(score);
        }
    }
}
