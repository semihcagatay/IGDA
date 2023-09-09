using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arabicmanager : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    bool canAttack = false;
    bool isAlive = true;
    int attackTime=3;
    float randomX;
    float randomY;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(setAttack());
        randomX = Random.Range(-10.0f,6.0f);
        randomY = Random.Range(0, 2.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("CanAttack", canAttack);
    }

    IEnumerator setAttack()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(attackTime);
            canAttack = !canAttack;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("Teleport",true);
    }
    public void teleport()
    {
        transform.position=new Vector2(randomX, randomY);
        //animator.SetBool("Reback",true);
        animator.SetBool("Teleport", false); 
        randomX = Random.Range(-10.0f, 6.0f);
        randomY = Random.Range(0, 2.5f);
    }

}
