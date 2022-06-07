using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Waypoint startPoint;
    [SerializeField] private Waypoint finishPoint;
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    void Start()
    {
        LoadBlocks();
        SetColorStartAndEnd();
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
                /*foreach (KeyValuePair<Vector2Int,Waypoint> waipoints in grid)
                {
                    KeyValuePair<Vector2Int,Waypoint> start1 = waipoints;
                    if (start1.Key.x < waipoints.Key.x && start1.Key.y <= waipoints.Key.y)
                    {
                        if (start1.Key.x <= waipoints.Key.x && start1.Key.y < waipoints.Key.y)
                        {
                            start1 = waipoints;
                        }
                        else
                        {
                            start1 = waipoints;
                        }
                    }
                    else
                    {
                        continue;
                    }
                    //start1.Value.SetTopColor(Color.black);
                    //waypoint.SetTopColor(Color.black);
                    
                }*/
            }
        }
    }

    private void SetColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        finishPoint.SetTopColor(Color.red);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
