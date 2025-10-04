using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [Header("Flight")]
    public float speed = 8f;
    public float hitRadius = 0.3f;      // 거리 판정 여유
    public float maxLifetime = 6f;      // 고아 탄 방지

    [Header("Damage")]
    public int damage = 5;

    private Transform target;
    private Rigidbody2D rb;
    private float life;

    // 풀링 대비 초기화
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.gravityScale = 0f;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true; // 충돌은 Trigger로만
    }

    private void OnEnable()
    {
        life = 0f;
    }

    public void Init(Transform t)
    {
        target = t;
    }

    private void FixedUpdate()
    {
        life += Time.fixedDeltaTime;
        if (life > maxLifetime) { Destroy(gameObject); return; }

        if (target == null) { Destroy(gameObject); return; }

        // 이동
        Vector2 pos = rb ? rb.position : (Vector2)transform.position;
        Vector2 next = Vector2.MoveTowards(pos, target.position, speed * Time.fixedDeltaTime);

        if (rb) rb.MovePosition(next);
        else transform.position = next;

        // 보정용 거리 히트
        float dist = Vector2.Distance(next, target.position);
        if (dist <= hitRadius)
        {
            ApplyDamage(target);
            Destroy(gameObject);
        }
    }

    // 콜라이더가 맞닿는 경우(Trigger)에도 처리
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (target == null) return;

        // 타깃 콜라이더거나, Health 달린 적과 닿았으면 히트 처리
        if (other.transform == target || other.GetComponent<Health>() != null)
        {
            ApplyDamage(other.transform);
            Destroy(gameObject);
        }
    }

    private void ApplyDamage(Transform victim)
    {
        if (victim == null) return;
        var h = victim.GetComponent<Health>();
        if (h != null) h.TakeDamage(damage);
    }
}
