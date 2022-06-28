using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Waypoint : MonoBehaviour
{
    /*[SerializeField] private Color exploredColor = Color.yellow;*/
    public Waypoint exploredFrom;
    public bool isExplored = false;
    private Vector2Int gridPos;
    
    //размер сетки 
    private const int gridSize = 10;

    public void Update()
    {
        /*if (isExplored)
        {
            SetTopColor(exploredColor);
        }*/
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize), //формула перемещения по сетке
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
    
}
