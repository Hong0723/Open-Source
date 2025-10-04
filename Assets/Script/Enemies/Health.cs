using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHP = 40f;
    [SerializeField] private Healthbar healthbarPrefab;

    private float currentHP;
    private Healthbar hb;

    public Healthbar HealthbarPrefab => healthbarPrefab;

    private void Awake()
    {
        currentHP = maxHP;
        if (maxHP <= 0f)
            Debug.LogWarning($"[Health:{name}] maxHP가 {maxHP}입니다. 0 이하면 즉시 죽습니다.", this);
    }

    public void AttachHealthbar(Healthbar bar)
    {
        if (bar == null)
        {
            Debug.LogError($"[Health:{name}] AttachHealthbar에 null이 들어왔습니다.", this);
            return;
        }

        hb = bar;

        if (!hb.IsConfigured)
            Debug.LogError($"[Health:{name}] 연결된 Healthbar의 Fill이 비어있습니다. 프리팹을 확인하세요.", hb);

        hb.Setup(transform, maxHP, currentHP);
        Debug.Log($"[Health:{name}] Healthbar 연결 완료. HP {currentHP}/{maxHP}");
    }

    public void TakeDamage(float amount)
    {
        float before = currentHP;
        currentHP = Mathf.Clamp(currentHP - amount, 0f, maxHP);

        if (hb == null)
            Debug.LogWarning($"[Health:{name}] Healthbar가 연결되지 않았습니다. HP만 내부적으로 감소합니다.");

        hb?.UpdateHealth(currentHP, maxHP);

        Debug.Log($"[Health:{name}] 데미지 {amount} → {before} ▶ {currentHP} / {maxHP}");

        if (currentHP <= 0f)
        {
            Debug.Log($"[Health:{name}] 사망. GameObject 파괴.");
            Destroy(gameObject);
        }
    }
}
