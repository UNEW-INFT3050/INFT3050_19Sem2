using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week12_AspNetCore.Models
{
    public class HighScoreTable
    {
        List<HighScore> m_scores = new List<HighScore>();
        public HighScoreTable(int size, int highestscore, int decrement)
        {
            // create defaults 'AAA' : 10000, 'BBB' : 9000 etc
            for (int i = 0; i < size; i++)
            {
                HighScore highScore = new HighScore();
                char letter = (char)('A' + i);
                highScore.Name = "" + letter + letter + letter;
                highScore.Score = highestscore - decrement * i;
                m_scores.Add(highScore);
            }
        }

        public IEnumerable<HighScore> Scores { get { return m_scores; } set { m_scores = new List<HighScore>(value); } }

    }
}
