using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;
    private Healthbar healthbar;

    void Awake()
    {
        health = GetComponent<Health>();
        healthbar = GetComponentInChildren<Healthbar>();

        if (health != null && healthbar != null)
        {
            healthbar.Setup(health);
        }
    }
}
