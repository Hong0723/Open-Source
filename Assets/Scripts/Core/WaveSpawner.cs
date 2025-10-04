// Scripts/Core/WaveSpawner.cs
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform[] waypoints;

    public float spawnInterval = 2f;
    public int enemiesPerWave = 5;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject e = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            e.GetComponent<EnemyMover>().waypoints = waypoints;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
