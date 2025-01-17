using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        // Move enemy towards waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Check if enemy is within proximity to waypoint and go next
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        // Check if at last waypoint
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

}
