using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    
    public int Health = 2;
    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;
    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;
        if(Health < 0)
        {
            Die();
        }
        EventOnTakeDamage.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
        EventOnDie.Invoke();
    }
}
