using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    float health = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.0f)
        {
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

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 position = transform.position;
        position.y += 0.1f;
        Handles.Label(transform.position, health.ToString());
    }
}
