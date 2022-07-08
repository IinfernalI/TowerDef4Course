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
    [SerializeField] private AudioClip hitEnemySoundFX;
    private Text scoreText;
    private int currentScore; // ошибка с текстом и поиск ...
    private AudioSource _audioSource;

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        HitDamage();
        if (health <= 0)
        {
            DestroyEnemy(deathParticle, true);
        }
    }

    public void DestroyEnemy(ParticleSystem particleFX,bool addScore)
    {
        if (addScore)
        {
            currentScore = int.Parse(scoreText.text);
            currentScore++;
            scoreText.text = currentScore.ToString();
        }

        ParticleSystem deadParticle = Instantiate(particleFX, transform.position, Quaternion.identity);
        deadParticle.Play();
        float deadParticleDuration = deadParticle.main.duration;
        
        Destroy(deadParticle.gameObject,deadParticleDuration); 
        Destroy(gameObject);
    }
    
    private void HitDamage()
    {
        _audioSource.PlayOneShot(hitEnemySoundFX);
        hitParticle.Play();
        health -= 1;
    }
}
