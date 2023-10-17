using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    float lowerBoundY = -5.5f;

    [SerializeField]
    EnemySpawner EnemySpawner;

    private void Update()
    {
        Vector3 newPosition = transform.position + Vector3.down * speed * Time.deltaTime;
        transform.position = newPosition;

        // destroy if enemy goes below lower bound
        if (transform.position.y < lowerBoundY)
        {
            // TODO: modify this to notify manager object instead of directly destroying

            //EnemySpawner.DestroyEnemy(gameObject); 
            Destroy(gameObject);
        }
    }
}