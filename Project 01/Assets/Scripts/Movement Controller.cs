using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;
    Vector3 objectDirection = Vector3.zero;

    [SerializeField]
    CollisionManager collisionManager;

    [SerializeField]
    float speed = 1f;

    Vector3 velocity = Vector3.zero;

    private Camera mainCamera;

    private float leftEdge;
    private float rightEdge;
    private float topEdge;
    private float bottomEdge;

    [SerializeField]
    GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CalculateEdges();
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (objectDirection * speed) * Time.deltaTime;

        objectPosition += velocity;

        // clamp horizontal position
        objectPosition.x = Mathf.Clamp(objectPosition.x, leftEdge, rightEdge);

        // clamp vertical position
        objectPosition.y = Mathf.Clamp(objectPosition.y, bottomEdge, topEdge);


        transform.position = objectPosition;
    }

    public void SetDirection(Vector3 newDirection)
    {
        objectDirection = newDirection.normalized;

        if (objectDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, objectDirection);
        }
    }

    void CalculateEdges()
    {
        // calculate screen edges
        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        leftEdge = bottomLeft.x;
        rightEdge = topRight.x;
        bottomEdge = bottomLeft.y;
        topEdge = topRight.y;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + objectDirection);
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // add bullet to collision manager
        collisionManager.AddCollidable(bullet.GetComponent<SpriteInfo>());
    }
}
