using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    Text currentScoreText;
    [SerializeField]
    Text highScoreText;

    [SerializeField]
    Text gameOverScoreText;
    [SerializeField]
    Text gameOverHighScoreText;

    private int currentScore = 0;
    private int highScore = 0;

    private const string HighScoreKey = "HighScore";

    void Start()
    {
        // load high score
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateHighScoreText();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
        gameOverHighScoreText.text = "High Score: " + highScore.ToString();
    }

    /// <summary>
    /// Updates the score by the given amount and updates the high score if necessary.
    /// </summary>
    /// <param name="points">The amount by which to increase the score. Can be negative.</param>
    public void UpdateScore(int points)
    {
        currentScore += points;

        // update score text
        currentScoreText.text = "Score: " + currentScore.ToString();
        gameOverScoreText.text = "Score: " + currentScore.ToString();

        // update high score if necessary
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            UpdateHighScoreText();
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        currentScoreText.text = "Score: " + currentScore.ToString();
        gameOverScoreText.text = "Score: " + currentScore.ToString();
    }
}
