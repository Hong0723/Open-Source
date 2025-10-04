using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public Health health;       // 연결: Enemy 오브젝트의 Health
    public Image hpBarFill;     // 연결: Healthbar 프리팹의 Fill(Image)

    void Start()
    {
        if (health != null)
        {
            health.OnHealthChanged += UpdateHealthBar;
            UpdateHealthBar(health.currentHP, health.maxHP); // 초기화
        }
    }

    void UpdateHealthBar(int current, int max)
    {
        if (hpBarFill != null)
        {
            hpBarFill.fillAmount = (float)current / max;
        }
    }
}
