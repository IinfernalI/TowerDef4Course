using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<Waypoint> waypoints;
    void Start()
    {
        PrintWaypointName();
        /*InvokeRepeating("PrintWaypointName",0f,1f);*/
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        Debug.Log("Enemy start running");
        foreach (Waypoint waypoint in waypoints)
        {
            transform.position = waypoint.transform.position;
            Debug.Log("Enemy go to - " + waypoint);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Enemy stoped");
    }
}
