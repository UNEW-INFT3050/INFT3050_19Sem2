using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Show ten top high scores
/// </summary>
public class HighScorePanel : MonoBehaviour {

    public GameObject textAnchor;
    public UnityEngine.UI.Text namePrefab;
    public UnityEngine.UI.Text scorePrefab;
    public float spacingY = 10;
    public float spacingX = 100;
    public HighScoreClient remoteClient;
    public NewHighScorePanel newHighScorePanel;

    private GameObject m_scoresBase;


    // Use this for initialization
    void Start()
    {
        LoadHighScores();

        if (GameScore.HasScore())
        {
            newHighScorePanel.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// load all high scores, set text when complete
    /// </summary>
    public void LoadHighScores()
    {
        remoteClient.GetHighScores(SetHighScoreText);
    }


    /// <summary>
    /// Test posting a high score
    /// </summary>
    public void TestNewHighScore()
    {
        NewHighScore("Fizban", 6789);
    }


    /// <summary>
    /// Post a new high score to the remote server
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    void NewHighScore(string name, int score)
    {
        HighScoreClient.ScorePair pair = new HighScoreClient.ScorePair();
        pair.Name = name;
        pair.Score = score;
        remoteClient.PostNewHighScore(pair, LoadHighScores);
    }

    /// <summary>
    /// Set the text of the high score table
    /// </summary>
    /// <param name="scoreTable"></param>
    private void SetHighScoreText(HighScoreClient.ScoreTable scoreTable)
    {
        if (m_scoresBase != null)
        {
            GameObject.Destroy(m_scoresBase);
        }
        m_scoresBase = Instantiate(textAnchor, transform, false);
        //m_scoresBase.transform.SetParent(transform, false);

        float offset = 0;
        foreach (var score in scoreTable.Scores)
        {
            var nameObj = Instantiate(namePrefab);
            nameObj.transform.SetParent(m_scoresBase.transform, false);
            nameObj.transform.localPosition = new Vector3(-spacingX, -offset, 0);
            nameObj.text = score.Name.Trim();

            var scoreObj = Instantiate(scorePrefab);
            scoreObj.transform.SetParent(m_scoresBase.transform, false);
            scoreObj.transform.localPosition = new Vector3(spacingX, -offset, 0);
            scoreObj.text += score.Score.ToString();

            offset += spacingY;
        }

    }
}
