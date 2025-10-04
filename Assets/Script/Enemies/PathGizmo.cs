using UnityEngine;

[ExecuteAlways]
public class PathGizmo : MonoBehaviour
{
    public Color lineColor = Color.yellow;

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        var points = GetComponentsInChildren<Transform>();
        for (int i = 1; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
    }
}
