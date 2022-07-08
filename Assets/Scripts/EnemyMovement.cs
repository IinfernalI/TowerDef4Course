using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


public class EnemyMovement : MonoBehaviour
{
    private Castle _castle;
    //[SerializeField] private Castle _castle; так же лучше?\\\\\\\\\\
    [SerializeField] private ParticleSystem castleDamageParticle;
    
    [Range(0,5)][SerializeField] private float speed;
    [Range(0,5)][SerializeField] private float moveStep;
    
    private PathFinder _pathFinder;

    private EnemyDamage _enemyDamage;

    private Vector3 targetPosition;
    

    void Start()
    {
        _castle = FindObjectOfType<Castle>();
        _enemyDamage = GetComponent<EnemyDamage>();
        _pathFinder = FindObjectOfType<PathFinder>();
        List<Waypoint> path = _pathFinder.GetPath();
        StartCoroutine(EnemyMove(path.Select(Selector).ToList())); //i => i.transform обсудить у сереги

        /*PathFinder _pathFinder2 = gameObject.GetComponent<PathFinder>();
        var path2 = _pathFinder2.GetPath();       //спросить у сереги на сколько этот код лучше или хуже 
        StartCoroutine(EnemyMove(path2));*/         //и нарушение зависимостей если одеть на обьект 2 скрипт
    }
    
    private void Update()
    {
        transform.position = Vector3.Lerp(this.transform.position,targetPosition,Time.deltaTime * moveStep);
    }

    private Transform Selector(Waypoint waypoint)
    {
        return waypoint.transform;
    }

    IEnumerator EnemyMove(List<Transform> path)
    {
        foreach (var waypoint in path)
        {
            transform.LookAt(waypoint);
            targetPosition = waypoint.transform.position;
            yield return new WaitForSeconds(speed);
        }
        _enemyDamage.DestroyEnemy(castleDamageParticle, false);
        _castle.DamageCastle();
    }
}
