using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Header("경로")]
    public Transform[] waypoints;   // Path의 자식들을 여기로 전달
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
                // 목적지 도착 시: 일단은 제거 (나중에 플레이어 HP 감소로 교체)
                Destroy(gameObject);
            }
        }
    }
}
