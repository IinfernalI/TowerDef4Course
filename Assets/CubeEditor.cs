using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    
    //атрибут показа    ползунок                 размер сетки 
    [SerializeField] [Range(1f,20f)] private int gridSize = 10;

    private TextMesh lebel;
    void Update()
    {
        
        
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x/gridSize) * gridSize; //формула перемещения по сетке
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPos; //кладем назад
        
        //берем компонент потомка текст меш
        lebel = GetComponentInChildren<TextMesh>();
        string labelName = "X-" + snapPos.x / gridSize + "," + "Z-" + snapPos.z / gridSize;
        lebel.text = labelName; //зарисовка самих кубов
        gameObject.name = labelName; //зарисовка каждого куба в меню
    }
}
