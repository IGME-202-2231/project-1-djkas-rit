using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    float radius = 1.0f;

    [SerializeField] 
    Vector2 rectSize = Vector2.one;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    bool useRendererBounds = false;
    
    bool isColliding = false;

    public Vector2 rectMin
    {
        get { return (Vector2)transform.position - (rectSize / 2); }
    }
    public Vector2 rectMax
    {
        get { return (Vector2)transform.position + (rectSize / 2); }
    }

    public float Radius
    {
        get { return radius; }
    }

    public bool IsColliding
    {
        set { isColliding = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

        if (useRendererBounds)
        {
            rectSize = spriteRenderer.bounds.extents * 2;
        }
    }

    private void OnDrawGizmos()
    {
        if (isColliding)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawWireCube(transform.position, rectSize);
    }
}
