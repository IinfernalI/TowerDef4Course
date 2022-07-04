using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int health;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

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
            Destroy(gameObject);
        }
    }
    
    private void HitDamage()
    {
        health -= 1;
    }
}
