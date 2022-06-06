using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    private Waypoint _waypoint;

    private void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        
        SnapToGrid();
        UpdateLabel();
        
    }

    private void UpdateLabel()
    {
        int gridSize = _waypoint.GetGridSize();
        //берем компонент потомка текст меш
        TextMesh lebel = GetComponentInChildren<TextMesh>();
        string labelName = "X-" + _waypoint.GetGridPos().x + "," + "Z-" + _waypoint.GetGridPos().y;
        lebel.text = labelName; //зарисовка самих кубов
        gameObject.name = labelName; //зарисовка каждого куба в меню
    }

    private void SnapToGrid()
    {
        int gridSize = _waypoint.GetGridSize();

        transform.position = new Vector3(_waypoint.GetGridPos().x * gridSize,0f,_waypoint.GetGridPos().y * gridSize); //кладем назад
    }
}
