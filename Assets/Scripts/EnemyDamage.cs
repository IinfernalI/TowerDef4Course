using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private ParticleSystem deathParticle;
    private Text scoreText;
    private int currentScore;
    [SerializeField] private int scoreOnDead = 150;

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

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
        currentScore = Convert.ToInt32(scoreText);
        currentScore++;
        scoreText.text = currentScore.ToString();
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
