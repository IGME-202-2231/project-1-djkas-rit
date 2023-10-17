using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    float spawnRate = 2.0f;
    [SerializeField]
    float spawnDelay = 1.0f;

    [SerializeField]
    CollisionManager collisionManager;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    public void SpawnEnemy()
    {
        float spawnX = Random.Range(-5.0f, 5.0f);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // add enemy to collision manager
        collisionManager.AddCollidable(enemy.GetComponent<SpriteInfo>());
    }

    public void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
}
