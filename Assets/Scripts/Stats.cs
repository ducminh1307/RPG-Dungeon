using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth;
    public int damage;

    private Entity entity;

    public int currentHealth { get; private set; }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        entity = GetComponent<Entity>();
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        int layerDefault = LayerMask.NameToLayer("Default");
        gameObject.layer = layerDefault;
        entity.Death();
    }

    public void Health(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
