using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Action onHealthChange;
    public Action onDeath;
    [SerializeField] private int maxHealth;
    private int health;
    private void Awake() {
        health = maxHealth;
    }
    public void TakeDamage(int amountOfDamage)
    {
        onHealthChange?.Invoke();
        health = health - amountOfDamage;
        if(health <= 0) 
        {
            health = 0;
            onDeath?.Invoke();
        }
    }
}
