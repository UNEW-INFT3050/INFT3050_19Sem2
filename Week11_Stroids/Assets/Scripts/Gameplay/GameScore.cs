using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {

    public Text scoreText;

    // using static here, so it stays persistent across Title and game scene (unity hack)
    static int s_Score = 0;

    public static bool HasScore()
    {
        return s_Score != 0;
    }

    public static void SetScore(int score)
    {
        s_Score = score;
    }

    public static int GetScore()
    {
        return s_Score;
    }

    public static void ClearScore()
    {
        s_Score = 0;
    }

	public void AddScore(int score)
    {
        s_Score += score;
        scoreText.text = "Score:" + s_Score.ToString();
    }
}
