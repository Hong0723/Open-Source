using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Transform[] waypoints;
    private int currentIndex = 0;

    public void Init(Transform[] points)
    {
        waypoints = points;
        currentIndex = 0;
        if (waypoints != null && waypoints.Length > 0)
            transform.position = waypoints[0].position;
    }

    //  WaveSpawner È£È¯¿ë
    public void Setup(Transform[] points) => Init(points);

    private void Update()
    {
        if (waypoints == null || currentIndex >= waypoints.Length) return;

        Transform target = waypoints[currentIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
                Destroy(gameObject);
        }
    }
}
