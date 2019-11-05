using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Push a new high score
public class NewHighScorePanel : MonoBehaviour {

    // input field for player's name
    public UnityEngine.UI.InputField nameInput;

    // server connection for high score
    public HighScoreClient highScoreClient;

    // Panel to show all high scores
    public HighScorePanel highScorePanel;

    //
    // Submit button
    public void Submit()
    {
        int score = GameScore.GetScore();

        // post high score
        string name = nameInput.text;
        HighScoreClient.ScorePair pair = new HighScoreClient.ScorePair();
        pair.Name = name;
        pair.Score = score;

        highScoreClient.PostNewHighScore(pair, OnComplete);
    }


    // 
    // When we've completed the process reshow high scores
    private void OnComplete()
    {
        highScorePanel.LoadHighScores();
        gameObject.SetActive(false);
        GameScore.ClearScore();
    }

    
}
