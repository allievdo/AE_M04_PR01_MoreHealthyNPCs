using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNeverDie : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
            Debug.Log("Damage taken");
        }
    }
    internal void TakeDamage(float amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }
}
