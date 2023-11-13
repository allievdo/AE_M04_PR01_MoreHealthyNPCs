﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;

    private int currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid damge amount specified: " + amount);
        }

        currentHealth -= amount;

        OnHPPctChanged(CurrentHpPct);

        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
