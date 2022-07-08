using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField][Range(1,5)] private float spawnInterval;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private AudioClip enemySpawnSoundFx;
    
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(enemySpawnSoundFx);
            EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = this.transform;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
}
