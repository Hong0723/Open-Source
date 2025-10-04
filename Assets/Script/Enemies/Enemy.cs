using UnityEngine;

[RequireComponent(typeof(Health))]
[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        if (health == null)
        {
            Debug.LogError($"[Enemy:{name}] Health 컴포넌트를 찾을 수 없습니다.", this);
            return;
        }

        if (health.HealthbarPrefab == null)
        {
            Debug.LogError($"[Enemy:{name}] Healthbar Prefab이 Health에 지정되어 있지 않습니다.", health);
            return;
        }

        var hb = Instantiate(health.HealthbarPrefab, transform);
        hb.transform.localPosition = new Vector3(0f, 0.5f, 0f);

        if (!hb.IsConfigured)
            Debug.LogError($"[Enemy:{name}] 인스턴스된 Healthbar의 Fill이 비어있습니다. 프리팹에서 Fill(Image) 연결 필요.", hb);

        health.AttachHealthbar(hb);
    }
}
