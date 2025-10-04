using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Header("���")]
    public Transform[] waypoints;   // Path�� �ڽĵ��� ����� ����
    public float speed = 2f;

    int index = 0;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[index];
        transform.position = Vector2.MoveTowards(
            transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            index++;
            if (index >= waypoints.Length)
            {
                // ������ ���� ��: �ϴ��� ���� (���߿� �÷��̾� HP ���ҷ� ��ü)
                Destroy(gameObject);
            }
        }
    }
}
