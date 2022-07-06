using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

[SelectionBase]

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    public bool isExplored = false;
    [SerializeField] public bool isPlaceble = true;
    
    Vector2Int gridPos; //убрать позже
    
    const int gridSize = 10;
    
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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceble)
        {
            Debug.Log($"Можем поставить башню: {gameObject}");
        }
        else if (Input.GetMouseButtonDown(0) && !isPlaceble)
        {
            Debug.Log("Не можем поставить башню");
        }
        
    }
}
