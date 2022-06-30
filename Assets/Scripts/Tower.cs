using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform towerTop;

    [SerializeField] private Transform targetEnemy;

    void Update()
    {
        towerTop.LookAt(targetEnemy);
    }
}
