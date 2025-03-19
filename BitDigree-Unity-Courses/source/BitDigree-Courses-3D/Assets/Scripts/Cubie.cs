using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubie : MonoBehaviour
{

    public string firstname = "null";

    [Tooltip("Waypoint List")]
    public List<Transform> waypoints = new List<Transform>();

    private int currentPoint = 0;
    private Transform currentWaypointTransform;

    void Start()
    {
        if (firstname == "null")
        {
            print("You have not set your name!");
        }

        currentWaypointTransform = waypoints[0];
    }

    void Update()
    {
        // if (currentPoint == 0) { currentWaypointTransform = waypoints[0]; }

        if (Vector3.Distance(this.transform.position, currentWaypointTransform.position) < 0.1f)
        {
            currentPoint += 1;
            if (currentPoint >= waypoints.Count)
            {
                currentPoint = 0;
            }

            currentWaypointTransform = waypoints[currentPoint];
        }

        transform.position = Vector3.MoveTowards(this.transform.position, currentWaypointTransform.position, 0.1f);
    }

}
