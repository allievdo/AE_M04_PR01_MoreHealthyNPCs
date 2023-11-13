using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfHitsHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int healthInHits = 5;

    [SerializeField]
    private float invulnerabilityTimeAfterEachHit = 5f;

    private int hitsRemaining;
    private bool canTakeDamage = true;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied =delegate { };

    public float CurrentHpPct
    {
        get { return (float) hitsRemaining / (float) healthInHits;}
    }

    private void Start()
    {
        hitsRemaining = healthInHits;
    }

    public void TakeDamage(float amount)
    {
        if (canTakeDamage)
        {
            StartCoroutine(InvulnerabilityTimer());

            hitsRemaining--;

            OnHPPctChanged(CurrentHpPct);

            if (hitsRemaining <= 0)
                OnDied();
        }
    }

    public void AddHealth(float amount)
    {
        OnHPPctChanged(CurrentHpPct);
        StartCoroutine(HealTimer());
    }

    private IEnumerator InvulnerabilityTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulnerabilityTimeAfterEachHit);
        canTakeDamage = true;
    }

    private IEnumerator HealTimer()
    {
        canTakeDamage = true;
        yield return new WaitForSeconds(10f);
        canTakeDamage= false;
    }
}
