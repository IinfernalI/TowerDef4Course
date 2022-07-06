using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int health;
    
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private ParticleSystem deathParticle;
    private void OnParticleCollision(GameObject other)
    {
        print("Попадание");
        HitDamage();
        CheckOnDestroyEnemy();
    }

    private void CheckOnDestroyEnemy()
    {
        if (health <= 0)
        {
            ParticleSystem deadParticle = Instantiate(deathParticle, transform.position, Quaternion.identity);
            deadParticle.Play();
            Destroy(gameObject);
        }
    }
    
    private void HitDamage()
    {
        hitParticle.Play();
        health -= 1;
    }
}
