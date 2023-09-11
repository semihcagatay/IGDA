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
    public static float randomXebabil;
    GameObject ebabil;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(setAttack());
        randomX = Random.Range(-10.0f,6.0f);
        randomY = Random.Range(0, 2.5f);
        ebabil = Resources.Load<GameObject>("Prefabs/ebabil");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator setAttack()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(attackTime);
            canAttack = !canAttack;
            animator.SetBool("CanAttack", canAttack);
            spawnEbabil();
           
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("Teleport",true);
        Debug.Log("collided with"+other.name);
    }
    public void teleport()
    {
        animator.SetBool("Teleport", false);
        transform.position=new Vector2(randomX, randomY);
        //animator.SetBool("Reback",true);
        
        randomX = Random.Range(-10.0f, 6.0f);
        randomY = Random.Range(0, 1.8f);
    }
    
    void spawnEbabil()
    {
        randomXebabil = Random.Range(-10.0f, 6.0f);
        Instantiate(ebabil);
    }
}
