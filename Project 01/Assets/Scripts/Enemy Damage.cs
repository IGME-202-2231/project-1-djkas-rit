using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    float health = 1.0f;
    [SerializeField]
    int pointValue = 100;

    ScoreManager scoreManager;
    
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (health <= 0.0f)
        {
            scoreManager.UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }

    public void takeDamage()
    {
        health -= 1.0f;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }
}
