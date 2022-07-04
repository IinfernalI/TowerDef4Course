using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private EnemyMovement enemyPrefab;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    void Update()
    {
        
    }
}
