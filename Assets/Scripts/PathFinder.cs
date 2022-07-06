using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Waypoint startPoint;
    [SerializeField] private Waypoint finishPoint;
    
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> _queue = new Queue<Waypoint>();
    
    bool _isRunning = true;
    Waypoint searchPoint;

    List<Waypoint> path = new List<Waypoint>();

    
    Vector2Int[] directions = new[]
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    
    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        PathFindAlgoritm();
        CreatePath();
    }

    void CreatePath()
    {
        AddPointToPath(finishPoint);
        Waypoint prevPoint = finishPoint.exploredFrom;
        while (prevPoint != startPoint)
        {
            AddPointToPath(prevPoint);
            prevPoint = prevPoint.exploredFrom;
        }
        AddPointToPath(prevPoint);
        path.Reverse();
    }

    private void AddPointToPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceble = false;
    }

    void PathFindAlgoritm()
    {
        _queue.Enqueue(startPoint);
        while(_queue.Count > 0 && _isRunning == true)
        {
            searchPoint = _queue.Dequeue();
            searchPoint.isExplored = true;
            CheckForEndPoint();
            ExploreNearPoints();
        }
        
    }

    void CheckForEndPoint()
    {
        if (searchPoint == finishPoint)
        {
            _isRunning = false;
        }
        else
        {
            _isRunning = true;
        }
    }

    void ExploreNearPoints()
    {
        if (!_isRunning) { return; }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nearPointCoordinates = searchPoint.GetGridPos() + direction;

            if(grid.ContainsKey(nearPointCoordinates)) 
            {
                Waypoint nearPoint = grid[nearPointCoordinates];
                AddPointToQueue(nearPoint);
            }
        }
    }

    void AddPointToQueue(Waypoint nearPoint)
    {
        if (nearPoint.isExplored || _queue.Contains(nearPoint)) //если исследован или уже есть в очереди
        {
            return;
        }
        else
        {
            _queue.Enqueue(nearPoint);
            nearPoint.exploredFrom = searchPoint;
        }
    }
    
    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos)) 
            {
                Debug.LogWarning("Повтор" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    /*void SetColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        finishPoint.SetTopColor(Color.red);
    }*/
}
