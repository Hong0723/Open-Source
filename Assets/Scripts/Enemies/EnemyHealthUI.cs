using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public Health health;       // ����: Enemy ������Ʈ�� Health
    public Image hpBarFill;     // ����: Healthbar �������� Fill(Image)

    void Start()
    {
        if (health != null)
        {
            health.OnHealthChanged += UpdateHealthBar;
            UpdateHealthBar(health.currentHP, health.maxHP); // �ʱ�ȭ
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
