using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform towerTop;

    [SerializeField] private Transform targetEnemy;

    [SerializeField] private float shootRange;

    [SerializeField] private ParticleSystem bulletParticle;

    void Update()
    {
        towerTop.LookAt(targetEnemy);
        if (targetEnemy) { Fire(); }
        else { Shoot(false); }
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
