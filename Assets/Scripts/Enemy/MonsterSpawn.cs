using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefabBear;
    private MonsterSpawnManager spawnPointManager;
    private float timeBetweenSpawns = 1;

    void Start()
    {
        spawnPointManager = GetComponent<MonsterSpawnManager>();
        InvokeRepeating("CreateMonster", 0, timeBetweenSpawns);
    }

    private void CreateMonster()
    {
        GameObject spawnPoint = spawnPointManager.GetNearestSpawnpoint(transform.position);

        if (spawnPoint)
        {
            GameObject newBear =
                (GameObject)Instantiate(prefabBear, spawnPoint.transform.position, Quaternion.identity);
            // Destroy(newBall, timeBetweenSpawns / 2);
        }
    }
}