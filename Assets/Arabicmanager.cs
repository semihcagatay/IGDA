using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arabicmanager : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    bool canAttack = true;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canAttack)
        {
            animator.SetBool("CanAttack", true);

        }
    }
    
}
