using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2f; // Speed of the enemy
    public Transform pointA; // First patrol point
    public Transform pointB; // Second patrol point
    private Vector3 target; // Current target position

    void Start()
    {
        target = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if the enemy has reached the target
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // Switch target between point A and point B
            target = target == pointA.position ? pointB.position : pointA.position;
        }


    }
}
