using System.Collections;
using UnityEngine;

public class MedusaManager : MonoBehaviour
{
    Animator animator;
    float attackCooldown = 3f;
    float nextAttackTime = 0f;
    MedusaHealthManager medusaHealthManager;
    public bool isAlive = true;
    public GameObject snake;
    public int positionX=10;
    public float randomY;
    public bool attack1;
    public bool attack2;
    Vector2 position;


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
        if(isAlive == false)
        {

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
            for(int i = 0; i < 3; i++)
            {
                randomY = Random.Range(1, -2);
                position = new Vector2(positionX, randomY);
                Attack2();
            }
            StartCoroutine("Attack2Cooldown");
        }
    }

    void Attack1()
    {
        attack1 = true;
        animator.SetBool("attack1", true);
        StartCoroutine("Attack1Cooldown");
    }

    void Attack2()
    {
        attack2 = true;
        animator.SetBool("attack2", true);
        Instantiate(snake, position, transform.rotation);
    }
    IEnumerator Attack1Cooldown()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("attack1", false);
        attack1 = false;
    }
    IEnumerator Attack2Cooldown()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("attack2", false);
        attack2 = false;
    }


}
