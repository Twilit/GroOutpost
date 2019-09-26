using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float nextWaypointDist = 1.2f;
    public int health = 3;

    public SpriteRenderer sprite;
    public GameObject deathEffect;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath = false;
    bool dying = false;

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
        if (seeker.IsDone() && !dying)
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

    public void DealDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            dying = true;
            GetComponent<CircleCollider2D>().enabled = false;
            rb.drag = 10f;
            sprite.color = new Color(1f, 1f, 1f, 0.3f);
            Invoke("Death", 0.5f);
        }
    }

    void Death()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
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

        if (!dying)
        {
            Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = dir * speed * Time.fixedDeltaTime;

            //rb.MovePosition(rb.position + force);
            rb.AddRelativeForce(force - rb.velocity);

            //rb.velocity = new Vector2 (Mathf.Clamp(rb.velocity.x, -4f, 4f), Mathf.Clamp(rb.velocity.y, -4f, 4f));

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDist)
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
}
