using UnityEngine;
using System.Collections.Generic;

public class AIKartController : MonoBehaviour
{
    RaceManager raceManager;


    public List<Transform> waypoints;
    public float speed = 10f;
    public float turnSpeed = 5f;
    public float waypointDistance = 3f;

    private int currentWaypoint = 0;
    private Rigidbody rb;

    void Start()
    {
        raceManager = FindObjectOfType<RaceManager>();

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!raceManager.raceStarted)
    return;

        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        if (waypoints.Count == 0) return;

        Transform target = waypoints[currentWaypoint];

        Vector3 direction = (target.position - transform.position).normalized;

        // Belok menuju waypoint
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.fixedDeltaTime);

        // Maju
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);

        // Jika sudah dekat waypoint → lanjut ke waypoint berikutnya
        if (Vector3.Distance(transform.position, target.position) < waypointDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
    }
}
