using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaManager : MonoBehaviour
{
    Animator animator;
    float attackCooldown = 3f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            RandomAttack();
            nextAttackTime = Time.time + attackCooldown;
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
        StartCoroutine(AttackCooldown());
    }

    void Attack2()
    {
        animator.SetBool("attack2", true);
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);
    }
}
