using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [Header("Flight")]
    public float speed = 8f;
    public float hitRadius = 0.3f;      // �Ÿ� ���� ����
    public float maxLifetime = 6f;      // ��� ź ����

    [Header("Damage")]
    public int damage = 5;

    private Transform target;
    private Rigidbody2D rb;
    private float life;

    // Ǯ�� ��� �ʱ�ȭ
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
        if (col != null) col.isTrigger = true; // �浹�� Trigger�θ�
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

        // �̵�
        Vector2 pos = rb ? rb.position : (Vector2)transform.position;
        Vector2 next = Vector2.MoveTowards(pos, target.position, speed * Time.fixedDeltaTime);

        if (rb) rb.MovePosition(next);
        else transform.position = next;

        // ������ �Ÿ� ��Ʈ
        float dist = Vector2.Distance(next, target.position);
        if (dist <= hitRadius)
        {
            ApplyDamage(target);
            Destroy(gameObject);
        }
    }

    // �ݶ��̴��� �´�� ���(Trigger)���� ó��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (target == null) return;

        // Ÿ�� �ݶ��̴��ų�, Health �޸� ���� ������� ��Ʈ ó��
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
