using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScoreClient : MonoBehaviour
{
    public string serverUrl = "http://localhost:16208/api/Scores";

    [System.Serializable]
    public class ScorePair
    {
        public string Name;
        public int Score;
    }

    [System.Serializable]
    public class ScoreTable
    {
        public ScorePair[] Scores;
    }


    public delegate void GetHighScoresDelegate(ScoreTable table);
    public delegate void CompletePostDelegate();

    public void GetHighScores(GetHighScoresDelegate onGetHighScores)
    {
        StartCoroutine(GetHighScoresCoroutine(onGetHighScores));
    }


    //
    // get high scores from the server
    IEnumerator GetHighScoresCoroutine(GetHighScoresDelegate onGetHighScores)
    {
        using (var request = UnityWebRequest.Get(serverUrl))
        {
            yield return request.SendWebRequest();

            if (request.error == null)
            {
                // hacky workaround for bad unity json parsing
                var json = "{\"Scores\":" + request.downloadHandler.text + "}";
                print(json);
                ScoreTable scoreTable = JsonUtility.FromJson<ScoreTable>(json);
                onGetHighScores(scoreTable);
            }
            else
            {
                print(request.error);
            }

        }
    }


    //
    // Post a new high score to the server
    public void PostNewHighScore(ScorePair pair, CompletePostDelegate onComplete)
    {
        StartCoroutine(PostNewHighScoreCoroutine(pair, onComplete));
    }

    IEnumerator PostNewHighScoreCoroutine(ScorePair pair, CompletePostDelegate onComplete)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", pair.Name);
        form.AddField("Score", pair.Score);

        using (var request = UnityWebRequest.Post(serverUrl, form))
        {
            yield return request.SendWebRequest();
            if (request.error == null)
            {
                onComplete();
            }
            else
            {
                print(request.error);
            }
        }
    }
}
