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
        // ��ǥ�� ������ �ڱ� �ڽ� ����
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // ��ǥ�� �̵�
        transform.position = Vector2.MoveTowards(
            transform.position, target.position, speed * Time.deltaTime);

        // �浹 üũ
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            Health h = target.GetComponent<Health>();
            if (h != null) h.Take(damage);

            Destroy(gameObject);
        }
    }
}