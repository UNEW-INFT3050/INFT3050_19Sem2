using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week11_HighScore.Controllers
{
    public class DefaultController : Controller
    {
        private DataAccess.DBScore m_scoreDB = new DataAccess.DBScore();

        // GET: Default
        public ActionResult Index()
        {
            var highScores = m_scoreDB.GetHighScores();
            return View(highScores);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}