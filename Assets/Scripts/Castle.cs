using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] private int playerLife = 10;
    [SerializeField] private int damageCastle = 1;
    [SerializeField] private Text textLife;
    [SerializeField] private AudioClip castleDamageSoundFx;

    private AudioSource _audioSource;

    private void Start()
    {
        textLife.text = Convert.ToString(playerLife);
        _audioSource = GetComponent<AudioSource>();
    }

    public void DamageCastle()
    {
        _audioSource.PlayOneShot(castleDamageSoundFx);
        playerLife -= damageCastle;
        textLife.text = Convert.ToString(playerLife);
    }
}
