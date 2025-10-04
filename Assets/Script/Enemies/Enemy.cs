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
            Debug.LogError($"[Enemy:{name}] Health ������Ʈ�� ã�� �� �����ϴ�.", this);
            return;
        }

        if (health.HealthbarPrefab == null)
        {
            Debug.LogError($"[Enemy:{name}] Healthbar Prefab�� Health�� �����Ǿ� ���� �ʽ��ϴ�.", health);
            return;
        }

        var hb = Instantiate(health.HealthbarPrefab, transform);
        hb.transform.localPosition = new Vector3(0f, 0.5f, 0f);

        if (!hb.IsConfigured)
            Debug.LogError($"[Enemy:{name}] �ν��Ͻ��� Healthbar�� Fill�� ����ֽ��ϴ�. �����տ��� Fill(Image) ���� �ʿ�.", hb);

        health.AttachHealthbar(hb);
    }
}
