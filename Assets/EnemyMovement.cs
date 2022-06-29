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
        StartCoroutine(EnemyMove(path));

        /*PathFinder _pathFinder2 = gameObject.GetComponent<PathFinder>();
        var path2 = _pathFinder2.GetPath();       //спросить у сереги на сколько этот код лучше или хуже 
        StartCoroutine(EnemyMove(path2));*/         //и нарушение зависимостей если одеть на обьект 2 скрипт
    }

    IEnumerator EnemyMove(List<Waypoint> path)
    {
        Debug.Log("Enemy start running");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Enemy stoped");
    }
}
