using UnityEngine;
using System.Collections.Generic;

public class AIKartInput : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 8f;
    public float turnSpeed = 5f;
    public float waypointDistance = 3f;

    int currentWaypoint = 0;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (waypoints == null || waypoints.Count == 0) return;

        Vector3 dir = waypoints[currentWaypoint].position - transform.position;
        dir.y = 0;

        Quaternion targetRot = Quaternion.LookRotation(dir);
        rb.MoveRotation(
            Quaternion.Slerp(rb.rotation, targetRot, turnSpeed * Time.fixedDeltaTime)
        );

        rb.MovePosition(
            rb.position + transform.forward * speed * Time.fixedDeltaTime
        );

        if (dir.magnitude < waypointDistance)
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
    }
}
