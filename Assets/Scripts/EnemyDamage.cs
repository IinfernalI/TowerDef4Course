using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public int health;
    
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private ParticleSystem deathParticle;
    
    private void OnParticleCollision(GameObject other)
    {
        HitDamage();
        if (health <= 0)
        {
            DestroyEnemy(deathParticle);
        }
    }

    public void DestroyEnemy(ParticleSystem particleFX)
    {
        ParticleSystem deadParticle = Instantiate(particleFX, transform.position, Quaternion.identity);
        deadParticle.Play();
        float deadParticleDuration = deadParticle.main.duration;
        Destroy(deadParticle.gameObject,deadParticleDuration); 
        Destroy(gameObject);
    }
    
    private void HitDamage()
    {
        hitParticle.Play();
        health -= 1;
    }
}
