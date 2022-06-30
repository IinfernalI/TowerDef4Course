using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


public class EnemyMovement : MonoBehaviour
{
    PathFinder _pathFinder;
    
    void Start()
    {
        _pathFinder = FindObjectOfType<PathFinder>();
        var path = _pathFinder.GetPath();
        StartCoroutine(EnemyMove(path.Select(Selector).ToList())); //i => i.transform обсудить у сереги

        /*PathFinder _pathFinder2 = gameObject.GetComponent<PathFinder>();
        var path2 = _pathFinder2.GetPath();       //спросить у сереги на сколько этот код лучше или хуже 
        StartCoroutine(EnemyMove(path2));*/         //и нарушение зависимостей если одеть на обьект 2 скрипт
    }

    private Transform Selector(Waypoint waypoint)
    {
        return waypoint.transform;
    }

    IEnumerator EnemyMove(List<Transform> path)
    {
        Debug.Log("Enemy start running");
        foreach (var waypoint in path)
        {
            transform.LookAt(waypoint);
            transform.position = waypoint.position;
            yield return new WaitForSeconds(1.5f);
        }
        Debug.Log("Enemy stoped");
    }
}
