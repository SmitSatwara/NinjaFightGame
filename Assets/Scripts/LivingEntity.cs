using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    [SerializeField]
    float currentHealth;
    public float maxHealth;

    public virtual void Start()
    {
        currentHealth = maxHealth;
        //Debug.Log(gameObject.name + " " + currentHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0.0f)
        {
            OnDeath();
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public virtual void OnDeath()
    {

    }
}
