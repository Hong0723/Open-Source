using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform[] pathPoints;

    private bool isSpawning = false;

    public void StartWave(int enemyCount, float spawnInterval)
    {
        isSpawning = true;
        StartCoroutine(SpawnEnemies(enemyCount, spawnInterval));
    }

    public void StopWave()
    {
        isSpawning = false;
    }

    private IEnumerator SpawnEnemies(int count, float interval)
    {
        for (int i = 0; i < count; i++)
        {
            if (!isSpawning)
                yield break;

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            var mover = enemy.GetComponent<EnemyMover>();
            if (mover != null)
                mover.Init(pathPoints);

            yield return new WaitForSeconds(interval);
        }
    }
}
