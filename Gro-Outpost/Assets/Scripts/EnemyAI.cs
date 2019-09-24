using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float nextWaypointDist = 1.2f;

    public SpriteRenderer sprite;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
            return;
        }
        else
        {
            reachedEndofPath = false;
        }

        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.fixedDeltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDist)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            sprite.flipX = true;
        }
        else if (rb.velocity.x <= 0.01f)
        {
            sprite.flipX = false;
        }
    }
}
