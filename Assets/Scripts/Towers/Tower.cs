using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;                 // ���� ����
    public float fireRate = 1.0f;            // �ʴ� �߻� Ƚ��
    public GameObject projectilePrefab;      // �߻�ü ������

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
            Debug.LogError("Projectile Prefab�� Tower�� ������� �ʾҽ��ϴ�!");
            return;
        }

        GameObject p = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Projectile ������Ʈ Ȯ��
        Projectile proj = p.GetComponent<Projectile>();
        if (proj != null) proj.Init(t);
        else Debug.LogError("Projectile �����տ� Projectile ��ũ��Ʈ�� ���� �ֽ��ϴ�!");
    }

    // �����Ϳ��� ��Ÿ� Ȯ�ο�
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
