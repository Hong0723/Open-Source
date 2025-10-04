using UnityEngine;

[DisallowMultipleComponent]
public class Tower : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float fireInterval = 0.7f;
    [SerializeField] private float range = 4.5f;

    private float timer;

    private void OnValidate()
    {
        if (projectilePrefab == null)
            Debug.LogError($"[Tower:{name}] Projectile Prefab�� ����ֽ��ϴ�.", this);
        if (range <= 0f)
            Debug.LogWarning($"[Tower:{name}] ��Ÿ�(range)�� {range} �Դϴ�.", this);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < fireInterval) return;

        var target = FindNearestEnemyInRange();
        if (target != null)
        {
            var p = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            p.Init(target);
            timer = 0f;
        }
        else
        {
            Debug.LogWarning($"[Tower:{name}] ��Ÿ� {range} �� ���� �����ϴ�.");
            timer = 0f; // ������ �α� ���������� ��ٿ��� ����
        }
    }

    private Transform FindNearestEnemyInRange()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies == null || enemies.Length == 0)
        {
            // �±� ���� ����Ʈ
            Debug.LogWarning("[Tower] 'Enemy' �±׸� ���� ������Ʈ�� �ϳ��� �����ϴ�. ������ Tag�� 'Enemy'�� �����ϼ���.");
            return null;
        }

        Transform best = null;
        float bestDist = float.MaxValue;

        foreach (var e in enemies)
        {
            float d = Vector2.Distance(transform.position, e.transform.position);
            if (d < bestDist && d <= range)
            {
                best = e.transform;
                bestDist = d;
            }
        }

        return best;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
