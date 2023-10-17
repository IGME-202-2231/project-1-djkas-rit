using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collidables = new List<SpriteInfo>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // remove nulls
        collidables.RemoveAll(item => item == null);

        // set all sprites to not colliding
        foreach (SpriteInfo collidable in collidables)
        {
            collidable.IsColliding = false;
        }

        // check for collisions
        for (int i = 0; i < collidables.Count - 1; i++)
        {
            for (int j = i + 1; j < collidables.Count; j++)
            {
                if (AABB(collidables[i], collidables[j]))
                {
                    collidables[i].IsColliding = true;
                    collidables[j].IsColliding = true;
                }
            }
        }
    }

    bool AABB(SpriteInfo a, SpriteInfo b)
    {
        return (b.rectMin.x < a.rectMax.x &&
            b.rectMax.x > a.rectMin.x &&
            b.rectMax.y > a.rectMin.y &&
            b.rectMin.y < a.rectMax.y);
    }

    public void AddCollidable(SpriteInfo collidable)
    {
        collidables.Add(collidable);
    }

    public void RemoveCollidable(SpriteInfo collidable)
    {
        collidables.Remove(collidable);
    }
}
