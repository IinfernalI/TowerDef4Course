using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Tower : MonoBehaviour
{
    [SerializeField] private Transform towerTop;

    [SerializeField] private Transform targetEnemy;

    [SerializeField] private float shootRange;

    [SerializeField] private ParticleSystem bulletParticle;

    void Update()
    {
        CloseEnemy();

        if (targetEnemy)
        {
            towerTop.LookAt(targetEnemy);
            Fire();
        }
        else { Shoot(false); }
    }

    private void CloseEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }
        Transform closestEnemy = sceneEnemies[0].transform;

        for (int i = 0; i < sceneEnemies.Length; i++)
        {
            closestEnemy = GetClosestEnemy(closestEnemy.transform, sceneEnemies[i].transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform enemyA, Transform enemyB)
    {
        var distA = Vector3.Distance(enemyA.position, transform.position);
        var distB = Vector3.Distance(enemyB.position, transform.position);
        if (distA > distB)
        {
            return enemyB;
        }

        return enemyA;
    }

    private void Fire()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        if (distanceToEnemy <= shootRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool canShoot)
    {
        //bulletParticle.enableEmission = canShoot;   Метод устарел
        var emission = bulletParticle.emission;
        emission.enabled = canShoot;
    }
}
