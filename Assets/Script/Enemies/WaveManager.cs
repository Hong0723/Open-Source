using System.Collections;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [Header("연결할 스크립트")]
    [SerializeField] private WaveSpawner spawner;
    [SerializeField] private TMP_Text waveText;

    [Header("웨이브 데이터")]
    [SerializeField] private WaveData[] waves;  // 여러 웨이브 설정

    [SerializeField] private float preStartDelay = 15f;   // 첫 웨이브 대기
    [SerializeField] private float intermissionTime = 20f;

    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        // 첫 웨이브 시작 전 대기
        float timer = preStartDelay;
        while (timer > 0)
        {
            waveText.text = $"Wave 1 준비: {Mathf.Ceil(timer)}초";
            timer -= Time.deltaTime;
            yield return null;
        }

        while (true)
        {
            if (currentWave >= waves.Length)
            {
                waveText.text = "게임 승리";
                yield break;
            }

            var wave = waves[currentWave];
            currentWave++;
            Debug.Log($"Wave {currentWave} 시작!");

            // Wave 시작 텍스트
            waveText.text = $"Wave {currentWave} 시작!";
            yield return new WaitForSeconds(1f);

            // 스폰 시작
            spawner.StartWave(wave.enemyCount, wave.spawnInterval);

            // Wave 진행
            timer = wave.duration;
            while (timer > 0)
            {
                waveText.text = $"Wave {currentWave}: {Mathf.Ceil(timer)}초";
                timer -= Time.deltaTime;
                yield return null;
            }

            // 스폰 종료
            spawner.StopWave();
            waveText.text = $"Wave {currentWave} 종료!";
            yield return new WaitForSeconds(1f);

            // 대기
            timer = intermissionTime;
            while (timer > 0)
            {
                waveText.text = $"Wave {currentWave + 1} 준비: {Mathf.Ceil(timer)}초";
                timer -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
