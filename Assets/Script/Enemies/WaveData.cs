using UnityEngine;

[System.Serializable]
public class WaveData
{
    [Min(0)] public int enemyCount = 5;      // 웨이브당 적 수
    [Min(0.05f)] public float spawnInterval = 1.5f; // 스폰 간격(초)
    [Min(0.1f)] public float duration = 40f;  // 웨이브 진행 시간(초)
}
