using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    float upperBoundY = 5.5f;

    private void Update()
    {
        Vector3 newPosition = transform.position + Vector3.up * speed * Time.deltaTime;
        transform.position = newPosition;

        // destroy if enemy goes below lower bound
        if (transform.position.y > upperBoundY)
        {
            Destroy(gameObject);
        }
    }
}
