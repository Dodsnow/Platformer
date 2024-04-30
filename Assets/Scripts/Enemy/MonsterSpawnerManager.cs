using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    private GameObject[] spawnPoints;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        if (spawnPoints.Length < 1)
        {
            Debug.LogError("SpawnPointManager: No spawn points found!");
        }
    }

    public GameObject RandomSpawnPoint()
    {
        if (spawnPoints.Length < 1)
        {
            return null;
        }

        int r = Random.Range(0, spawnPoints.Length);
        return spawnPoints[r];
    }

    public GameObject GetNearestSpawnpoint(Vector2 source)
    {
        if (spawnPoints.Length < 1)
        {
            return null;
        }

        GameObject nearestSpawnPoint = spawnPoints[0];
        Vector2 spawnPointPos = spawnPoints[0].transform.position;
        float shortestDistance = Vector2.Distance(source, spawnPointPos);
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            spawnPointPos = spawnPoints[i].transform.position;
            float newDist = Vector2.Distance(source, spawnPointPos);
            if (newDist < shortestDistance)
            {
                shortestDistance = newDist;
                nearestSpawnPoint = spawnPoints[i];
            }
        }

        return nearestSpawnPoint;
    }
}