// Scripts/Towers/Node.cs
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Node : MonoBehaviour
{
    public GameObject towerOnTop;
    public Color hoverColor = Color.green;
    private Color originColor;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null) originColor = sr.color;
    }

    void OnMouseEnter()
    {
        if (sr != null) sr.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (sr != null) sr.color = originColor;
    }

    void OnMouseDown()
    {
        if (towerOnTop != null) return; // ÀÌ¹Ì ¼³Ä¡µÊ
        var bm = BuildManager.I;
        if (bm.selectedTower == null) return;

        var bank = FindObjectOfType<GoldBank>();
        if (!bank.Spend(bm.selectedCost)) return;

        towerOnTop = Instantiate(bm.selectedTower, transform.position, Quaternion.identity);
    }
}
