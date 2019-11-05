using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Week12_AspNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> m_logger;
        private readonly Services.JsonHighScoreService m_highScore;
        public IndexModel(ILogger<IndexModel> logger, Services.JsonHighScoreService jsonHighScoreService)
        {
            m_logger = logger;
            m_highScore = jsonHighScoreService;
        }

        public IEnumerable<Models.HighScore> Scores { get; private set; }

        public void OnGet()
        {
            Scores = m_highScore.HighScores.Scores;
        }

    }
}
