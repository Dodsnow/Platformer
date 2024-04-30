using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 3f;
    public SpawnPoint spawnpoint;
    public bool isSpawnDead = false;

    void Update()
    {
        StartCoroutine(SpawnUnit());
    }

    IEnumerator SpawnUnit()
    {
        if (isSpawnDead)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(spawnpoint.enemyPrefab, spawnpoint.transform.position, Quaternion.identity);
        }
    }
}