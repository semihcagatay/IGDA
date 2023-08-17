using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    RaycastHit2D[] groundsHits = new RaycastHit2D[5];
    public ContactFilter2D castFilter;
    CapsuleCollider2D touchingCol;
    private float groundDistance=0.05f;
    [SerializeField]
    private bool _isground;


    Animator animator;
    public bool isGround
    {
        get
        {
            return _isground;
        }
        private set
        {
            _isground = value;
            animator.SetBool("IsOnground", value);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = touchingCol.Cast(Vector2.down, castFilter, groundsHits, groundDistance) > 0;
    }
}
