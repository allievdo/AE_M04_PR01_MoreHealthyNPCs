using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHeal : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            AddHealth(10);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //    AddHealth(5);
        //}
    }
    internal void TakeDamage(float amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }
    internal void AddHealth(float amount)
    {
        GetComponent<IHealth>().AddHealth(amount);
    }
}
