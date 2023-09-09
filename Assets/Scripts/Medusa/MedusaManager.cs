using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaManager : MonoBehaviour
{
    Animator animator;
    float attackCooldown = 3f;
    float nextAttackTime = 0f;
    MedusaHealthManager medusaHealthManager;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        medusaHealthManager = GetComponent<MedusaHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime && isAlive)
        {
            RandomAttack();
            nextAttackTime = Time.time + attackCooldown;
        }
        if(medusaHealthManager.currentHealth <= 0)
        {
            isAlive = false;
        }
    }

    void RandomAttack()
    {
        int randomAttackNumber = Random.Range(1, 3);

        if (randomAttackNumber == 1)
        {
            Attack1();
        }
        else if (randomAttackNumber == 2)
        {
            Attack2();
        }
    }

    void Attack1()
    {
        animator.SetBool("attack1", true);
        StartCoroutine("Attack1Cooldown");
    }

    void Attack2()
    {
        animator.SetBool("attack2", true);
        StartCoroutine("Attack2Cooldown");
    }
    IEnumerator Attack1Cooldown()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("attack1", false);
    }
    IEnumerator Attack2Cooldown()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("attack2", false);
    }
}
