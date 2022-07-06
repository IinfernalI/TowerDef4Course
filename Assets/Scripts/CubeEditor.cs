using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint _waypoint;

    void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
    
    void SnapToGrid()
    {
        int gridSize = _waypoint.GetGridSize();
        transform.position = new Vector3(_waypoint.GetGridPos().x * gridSize,0f,_waypoint.GetGridPos().y * gridSize); //работа сетки
    }
    
    void UpdateLabel()
    {
        TextMesh lebel = GetComponentInChildren<TextMesh>(); //берем компонент потомка текст меш
        string labelName = "X" + _waypoint.GetGridPos().x + "," + "Z" + _waypoint.GetGridPos().y;
        lebel.text = labelName; //зарисовка самих лейблов кубов
        gameObject.name = labelName; //зарисовка каждого куба в меню
    }

    
}
