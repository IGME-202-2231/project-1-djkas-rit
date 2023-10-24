using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    int pointValue = 100;

    float lowerBoundY = -5.5f;

    [SerializeField]
    EnemySpawner EnemySpawner;

    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }
    private void Update()
    {
        Vector3 newPosition = transform.position + Vector3.down * speed * Time.deltaTime;
        transform.position = newPosition;

        // destroy if enemy goes below lower bound
        if (transform.position.y < lowerBoundY)
        {
            scoreManager.UpdateScore(-pointValue);
            Destroy(gameObject);
        }
    }
}