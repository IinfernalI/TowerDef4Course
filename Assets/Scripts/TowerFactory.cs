using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;
    [SerializeField] private int towerLimit = 4;
    
    private Queue<Tower> _towersQueue = new Queue<Tower>();
    

    public void AddTower(Waypoint waypoint)
    {
        if (_towersQueue.Count < towerLimit)
        {
            InstantiateNewTower(waypoint);
        }
        else
        {
            MoveTowerToNewPosition(waypoint);
        }
    }
    
    private void InstantiateNewTower(Waypoint waypoint)
    {
        Tower thisTower = Instantiate(_towerPrefab, waypoint.transform.position, Quaternion.identity);
        thisTower.transform.parent = this.transform;
        thisTower.prevWaypoint = waypoint;
        waypoint.isPlaceble = false;
        _towersQueue.Enqueue(thisTower);
    }
    
    private void MoveTowerToNewPosition(Waypoint waypoint)
    {
        Tower swapTower = _towersQueue.Dequeue();
        
        
        swapTower.transform.position = waypoint.transform.position;
        swapTower.prevWaypoint.isPlaceble = true;
        waypoint.isPlaceble = false;
        swapTower.prevWaypoint = waypoint;

        _towersQueue.Enqueue(swapTower);
    }
}
