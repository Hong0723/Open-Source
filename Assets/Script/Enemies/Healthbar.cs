using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image fillImage;   // 빨간색 체력바
    private Health health;

    public void Setup(Health health)
    {
        this.health = health;
        health.OnHealthChanged += UpdateHealthbar;
    }

    private void UpdateHealthbar(int currentHP, int maxHP)
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = (float)currentHP / maxHP;
        }
    }
}
