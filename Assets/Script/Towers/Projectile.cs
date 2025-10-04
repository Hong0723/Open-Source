using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 5;

    private Transform target;

    public void Init(Transform t)
    {
        target = t;
    }

    void Update()
    {
        // 목표가 없으면 자기 자신 제거
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // 목표로 이동
        transform.position = Vector2.MoveTowards(
            transform.position, target.position, speed * Time.deltaTime);

        // 충돌 체크
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            Health h = target.GetComponent<Health>();
            if (h != null) h.Take(damage);

            Destroy(gameObject);
        }
    }
}