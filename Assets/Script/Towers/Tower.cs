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
            Debug.LogError($"[Tower:{name}] Projectile Prefab이 비어있습니다.", this);
        if (range <= 0f)
            Debug.LogWarning($"[Tower:{name}] 사거리(range)가 {range} 입니다.", this);
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
            Debug.LogWarning($"[Tower:{name}] 사거리 {range} 내 적이 없습니다.");
            timer = 0f; // 과도한 로그 방지용으로 쿨다운은 유지
        }
    }

    private Transform FindNearestEnemyInRange()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies == null || enemies.Length == 0)
        {
            // 태그 문제 디텍트
            Debug.LogWarning("[Tower] 'Enemy' 태그를 가진 오브젝트가 하나도 없습니다. 프리팹 Tag를 'Enemy'로 설정하세요.");
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
