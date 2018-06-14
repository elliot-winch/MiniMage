using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

    public float startingHealth;

    private float currentHealth;

    protected float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    protected virtual void Start()
    {
        CurrentHealth = startingHealth;
    }

    public virtual void Hit(float amount)
    {
        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);

        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
