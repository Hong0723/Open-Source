using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    // 체력 변경 이벤트 (UI에서 사용)
    public event Action<int, int> OnHealthChanged;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void Take(int amount)
    {
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;

        // 체력 변경 알림
        if (OnHealthChanged != null)
            OnHealthChanged(currentHP, maxHP);

        // 죽었을 때 처리
        if (currentHP == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
