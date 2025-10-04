using System.Collections;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [Header("������ ��ũ��Ʈ")]
    [SerializeField] private WaveSpawner spawner;
    [SerializeField] private TMP_Text waveText;

    [Header("���̺� ������")]
    [SerializeField] private WaveData[] waves;  // ���� ���̺� ����

    [SerializeField] private float preStartDelay = 15f;   // ù ���̺� ���
    [SerializeField] private float intermissionTime = 20f;

    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        // ù ���̺� ���� �� ���
        float timer = preStartDelay;
        while (timer > 0)
        {
            waveText.text = $"Wave 1 �غ�: {Mathf.Ceil(timer)}��";
            timer -= Time.deltaTime;
            yield return null;
        }

        while (true)
        {
            if (currentWave >= waves.Length)
            {
                waveText.text = "���� �¸�";
                yield break;
            }

            var wave = waves[currentWave];
            currentWave++;
            Debug.Log($"Wave {currentWave} ����!");

            // Wave ���� �ؽ�Ʈ
            waveText.text = $"Wave {currentWave} ����!";
            yield return new WaitForSeconds(1f);

            // ���� ����
            spawner.StartWave(wave.enemyCount, wave.spawnInterval);

            // Wave ����
            timer = wave.duration;
            while (timer > 0)
            {
                waveText.text = $"Wave {currentWave}: {Mathf.Ceil(timer)}��";
                timer -= Time.deltaTime;
                yield return null;
            }

            // ���� ����
            spawner.StopWave();
            waveText.text = $"Wave {currentWave} ����!";
            yield return new WaitForSeconds(1f);

            // ���
            timer = intermissionTime;
            while (timer > 0)
            {
                waveText.text = $"Wave {currentWave + 1} �غ�: {Mathf.Ceil(timer)}��";
                timer -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
