using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;
    private bool _invulnerable = false;
    //public AudioSource TakeDamageSound;
    public AudioSource AddHaelthSound;
    public HealthUI HealthUI;
    //public Blink Blink;
    //public DamageScreen DamageScreen;
    public UnityEvent EventOnTakeDamage;
    public GameObject Prefab;
    public Transform[] Spawn;



    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }
    public void TakeDamage(int damageValue)
    {
        if(_invulnerable == false)
        {
            Health -= damageValue;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            //TakeDamageSound.Play();
        }
        _invulnerable = true;

        Invoke("StopInvulnerable", 1f);
        HealthUI.DisplayHealth(Health);
        //Blink.StartBlink();
        //DamageScreen.StartEffect();
        EventOnTakeDamage.Invoke();
    }

    public void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;
        if(Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        AddHaelthSound.Play();
        HealthUI.DisplayHealth(Health);
    }
   
    public void Die()
    {
        Debug.Log("You Lose");
    }

}

