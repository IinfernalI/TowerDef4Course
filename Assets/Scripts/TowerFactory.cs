using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerFactory : MonoBehaviour
{
    
    [SerializeField] private Tower _towerPrefab;

    [SerializeField] private int towerLimit = 4;

    private int towerCounts;

    public void AddTower(Waypoint waypoint)
    {
        if (towerCounts < towerLimit)
        {
            InstantiateNewTower(waypoint);
        }
        else
        {
            MoveTowerToNewPosition(waypoint);
        }
    }

    private void MoveTowerToNewPosition(Waypoint waypoint)
    {
        Debug.Log("Передвинуть башню");
    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        Instantiate(_towerPrefab, waypoint.transform.position, Quaternion.identity);
        waypoint.isPlaceble = false;
        towerCounts++;
    }
}
