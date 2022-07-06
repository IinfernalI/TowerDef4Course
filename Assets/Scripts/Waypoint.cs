using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

[SelectionBase]

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    
    public bool isExplored = false;
    [SerializeField] public bool isPlaceble = true;
    [SerializeField] private Tower _towerPrefab;
    
    private Tower thisTower;
    
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
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceble)
            {
                thisTower = Instantiate(_towerPrefab, transform.position, Quaternion.identity);
                isPlaceble = false;
            }
            else
            {
                Debug.Log("Не можем поставить башню");
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (thisTower)
            {
                thisTower.DestroyTuttet();
                isPlaceble = true;
            }
            else
            {
                Debug.Log("У нас нет турели сдесь");
            }
        }
    }
}
