using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] private int playerLife = 10;
    [SerializeField] private int damageCastle = 1;

    public void DamageCastle()
    {
        playerLife -= damageCastle;
    }
}
