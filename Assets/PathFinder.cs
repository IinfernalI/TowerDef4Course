using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Waypoint startPoint;
    [SerializeField] private Waypoint finishPoint;
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    private Queue<Waypoint> _queue = new Queue<Waypoint>();
    private bool _isRunning = true;

    private Waypoint searchPoint;

    private Vector2Int[] directions = new[]
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    void Start()
    {
        LoadBlocks();
        SetColorStartAndEnd();
        //ExploreNearPoints();
        PathFind();
    }

    private void PathFind()
    {
        _queue.Enqueue(startPoint);
        while(_queue.Count > 0 && _isRunning == true)
        {
            searchPoint = _queue.Dequeue();
            searchPoint.isExplored = true;
            CheckForEndPoint();
            ExploreNearPoints();
            //print("Поиск завершен?");
        }
        
    }

    private void CheckForEndPoint()
    {
        if (searchPoint == finishPoint)
        {
            print($"{searchPoint} являеться конечной точкой");
            _isRunning = false;
        }
        else
        {
            print($"{searchPoint} не являеться последней точкой");
            _isRunning = true;
        }
    }

    private void ExploreNearPoints()
    {
        if (!_isRunning) { return; }
        else
        {
            foreach (Vector2Int direction in directions)
            {
                Vector2Int nearPointCoordinates = searchPoint.GetGridPos() + direction;

                try
                {
                    Waypoint nearPoint = grid[nearPointCoordinates];
                    AddPointToQueue(nearPoint);
                }
                catch
                {
                    //Debug.LogWarning($"Блок : {nearPointCoordinates} не существует!");
                }
            }
        }
    }

    private void AddPointToQueue(Waypoint nearPoint)
    {
        if (nearPoint.isExplored || _queue.Contains(nearPoint)) //если исследован или уже есть в очереди
        {
            return;
        }
        else
        {
            //nearPoint.SetTopColor(Color.yellow);
            _queue.Enqueue(nearPoint);
            nearPoint.exploredFrom = searchPoint;
            print($"Добавить в очередь - {nearPoint}");
        }
    }
    
    private void LoadBlocks()
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

    private void SetColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        finishPoint.SetTopColor(Color.red);
    }
    
    void Update()
    {
        
    }
}
