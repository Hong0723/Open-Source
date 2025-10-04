using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager I;               // 싱글톤
    public GameObject selectedTower;            // 선택된 타워 프리팹
    public int selectedCost = 100;              // 가격

    void Awake() { I = this; }

    // UI 버튼에서 호출하거나, 테스트용으로 인스펙터에서 직접 지정 가능
    public void SelectTower(GameObject prefab, int cost)
    {
        selectedTower = prefab;
        selectedCost = cost;
    }
}

