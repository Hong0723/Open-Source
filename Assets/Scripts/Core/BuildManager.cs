using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager I;               // �̱���
    public GameObject selectedTower;            // ���õ� Ÿ�� ������
    public int selectedCost = 100;              // ����

    void Awake() { I = this; }

    // UI ��ư���� ȣ���ϰų�, �׽�Ʈ������ �ν����Ϳ��� ���� ���� ����
    public void SelectTower(GameObject prefab, int cost)
    {
        selectedTower = prefab;
        selectedCost = cost;
    }
}

