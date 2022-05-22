using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Vector3 veloc;
    public float activeDistance=10f;
    public Animator animator;
    public Transform target;
     public float speedvalue = 0;
    
    public float speed= 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    Vector3 lastPosition = Vector3.zero;
     GameObject player;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");  
        target = player.transform;

        InvokeRepeating("UpdatePath",0f, .5f);


        
    }

    void UpdatePath()
    {   
        if (seeker.IsDone()&&TargetInDistance())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
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
        return;
                   
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        
        Vector2 force = direction * speed * Time.deltaTime;

        speedvalue = ((transform.position - lastPosition).magnitude)/Time.deltaTime;
        lastPosition = transform.position;
        animator.SetFloat("SpeedValue",speedvalue);
        veloc=rb.velocity;
        
        
        if (TargetInDistance())
        {
            rb.AddForce(force);
        }
        

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >=0.01f)
        {
            enemyGFX.localScale = new Vector3(-5f, 5f , 5f);
        }
        else if(force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(5f, 5f, 5f);
        }


    }
    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.position)< activeDistance;
    }
}
