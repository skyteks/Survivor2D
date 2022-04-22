using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    public FloatEvent onHealthChanged;

    public static PlayerHealth playerInstance { get; private set; }

    void Awake()
    {
        playerInstance = this;
        currentHealth = maxHealth;
    }

    public void Setup(int startHealth)
    {
        maxHealth = startHealth;
        currentHealth = startHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage);

        onHealthChanged?.Invoke(currentHealth / (float)maxHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("YOU DIED");
        Debug.Break();
    }
}
