using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    // ü�� ���� �̺�Ʈ (UI���� ���)
    public event Action<int, int> OnHealthChanged;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void Take(int amount)
    {
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;

        // ü�� ���� �˸�
        if (OnHealthChanged != null)
            OnHealthChanged(currentHP, maxHP);

        // �׾��� �� ó��
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
