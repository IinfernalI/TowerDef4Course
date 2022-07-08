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

    private void Start()
    {
        textLife.text = Convert.ToString(playerLife);
    }

    public void DamageCastle()
    {
        playerLife -= damageCastle;
        textLife.text = Convert.ToString(playerLife);
    }
}
