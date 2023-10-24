using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    [SerializeField]
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// Adds or subtracts points from the player's score and updates the high score if necessary
    /// </summary>
    /// <param name="points">The number of points to be added</param>
    /// <returns>The current score value</returns>
    public int UpdateScore(int points)
    {
        score += points;

        if (score > highScore)
        {
            highScore = score;
        }

        return score;
    }
}
