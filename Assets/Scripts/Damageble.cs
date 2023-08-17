using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0005 // Using directive is unnecessary.
using UnityEngine.Events;
#pragma warning restore IDE0005 // Using directive is unnecessary.

public class Damageble : MonoBehaviour
{
    public UnityEvent<float, float> calculateHealth;
    public UnityEvent< Vector2> damageableHit;
    Animator animator;
    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth 
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        } 
    }

    [SerializeField]
    private int _health = 100;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            calculateHealth?.Invoke(_health, MaxHealth);
            if (_health <= 0)
            {
                IsAlive = false;
            }


        }
    }

   

    [SerializeField]
    private bool _isAlive = true;
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            Debug.Log("IsAlive set: " + value);
            animator.SetBool("isAlive", value);
        }
    }
    public bool lockVelocity
    {
        get
        {
           return animator.GetBool("lockVelocity");
        }
        set
        {
            animator.SetBool("lockVelocity", value);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Hit(int attackDMG,Vector2 knockback)
    {
        if (IsAlive)
        {
            lockVelocity = true;
            animator.SetTrigger("Hit");
            Health -= attackDMG;
            
            damageableHit?.Invoke(knockback);
            return true;
        }
        return false;
    }
}

