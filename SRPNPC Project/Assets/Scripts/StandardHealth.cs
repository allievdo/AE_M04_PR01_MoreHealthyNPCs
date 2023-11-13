using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;
    //public int startingHealth;

    public float currentHealth;
    public AudioSource moo;

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

    public void TakeDamage(float amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);
        }

        currentHealth -= amount;

        OnHPPctChanged(CurrentHpPct);

        if (CurrentHpPct <= 0)
            Die();
    }

    public void AddHealth(float amount)
    {
        if (currentHealth != 100)
        {
            currentHealth += amount;

            OnHPPctChanged(CurrentHpPct);
        }
        else
            Debug.Log("HP = 100");
    }
        //if (amount <= 0)
        //{
        //    throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);
        //}

        //currentHealth -= amount;

        //OnHPPctChanged(CurrentHpPct);

        //if (CurrentHpPct <= 0)
        //    Die();

    private void Die()
    {
        moo.Play();
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
