using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;                 // 공격 범위
    public float fireRate = 1.0f;            // 초당 발사 횟수
    public GameObject projectilePrefab;      // 발사체 프리팹

    private float cd;

    void Update()
    {
        cd -= Time.deltaTime;
        if (cd > 0) return;

        Transform t = FindTarget();
        if (t == null) return;

        Shoot(t);
        cd = 1f / fireRate;
    }

    Transform FindTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform best = null;
        float bestDist = Mathf.Infinity;

        foreach (var e in enemies)
        {
            float d = Vector2.Distance(transform.position, e.transform.position);
            if (d < range && d < bestDist)
            {
                best = e.transform;
                bestDist = d;
            }
        }
        return best;
    }

    void Shoot(Transform t)
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile Prefab이 Tower에 연결되지 않았습니다!");
            return;
        }

        GameObject p = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Projectile 컴포넌트 확인
        Projectile proj = p.GetComponent<Projectile>();
        if (proj != null) proj.Init(t);
        else Debug.LogError("Projectile 프리팹에 Projectile 스크립트가 빠져 있습니다!");
    }

    // 에디터에서 사거리 확인용
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
