using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour //, IEnemyHolder
{
    
     public List<Tower> ListTowers;
     public List<Transform> ListTEST;
     public List<Transform> List => ListTEST;
    
    [ContextMenu("TESTIT")]
     public void TestIt()
     {
         foreach (Tower tower in ListTowers)
         {
            // tower.Init(this);
         }
     }
      [ContextMenu("STOP")]
     public void StopIt()
     {
         foreach (Tower tower in ListTowers)
         {
             //tower.Init(null);
         }
     }
     
     
    
    private void Awake()
    {
        Debug.Log($"Awake");
    }

    private void OnEnable()
    {
        Debug.Log($"OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Start");
    }



}
