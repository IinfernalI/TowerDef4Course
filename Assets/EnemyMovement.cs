using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class EnemyMovement : MonoBehaviour
{
    PathFinder _pathFinder;
    
    void Start()
    {
        _pathFinder = FindObjectOfType<PathFinder>();
        var path = _pathFinder.GetPath();
        StartCoroutine(enemyMove(path));
    }

    IEnumerator enemyMove(List<Waypoint> path)
    {
        Debug.Log("Enemy start running");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            Debug.Log("Enemy go to - " + waypoint);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Enemy stoped");
    }
}
