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
            Debug.LogWarning($"[Health:{name}] maxHP�� {maxHP}�Դϴ�. 0 ���ϸ� ��� �׽��ϴ�.", this);
    }

    public void AttachHealthbar(Healthbar bar)
    {
        if (bar == null)
        {
            Debug.LogError($"[Health:{name}] AttachHealthbar�� null�� ���Խ��ϴ�.", this);
            return;
        }

        hb = bar;

        if (!hb.IsConfigured)
            Debug.LogError($"[Health:{name}] ����� Healthbar�� Fill�� ����ֽ��ϴ�. �������� Ȯ���ϼ���.", hb);

        hb.Setup(transform, maxHP, currentHP);
        Debug.Log($"[Health:{name}] Healthbar ���� �Ϸ�. HP {currentHP}/{maxHP}");
    }

    public void TakeDamage(float amount)
    {
        float before = currentHP;
        currentHP = Mathf.Clamp(currentHP - amount, 0f, maxHP);

        if (hb == null)
            Debug.LogWarning($"[Health:{name}] Healthbar�� ������� �ʾҽ��ϴ�. HP�� ���������� �����մϴ�.");

        hb?.UpdateHealth(currentHP, maxHP);

        Debug.Log($"[Health:{name}] ������ {amount} �� {before} �� {currentHP} / {maxHP}");

        if (currentHP <= 0f)
        {
            Debug.Log($"[Health:{name}] ���. GameObject �ı�.");
            Destroy(gameObject);
        }
    }
}
