using UnityEngine;

[System.Serializable]
public class WaveData
{
    [Min(0)] public int enemyCount = 5;      // ���̺�� �� ��
    [Min(0.05f)] public float spawnInterval = 1.5f; // ���� ����(��)
    [Min(0.1f)] public float duration = 40f;  // ���̺� ���� �ð�(��)
}
