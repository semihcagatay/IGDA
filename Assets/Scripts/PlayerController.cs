using System.Collections;
//
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Damageble damageable;

    //Animator animator;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    Rigidbody2D rb;
    [SerializeField]
    //private bool _isDashed;
    private bool canDash=false;
   /* public bool isDashed
    {
      //  get { return animator.GetBool(""); } set { animator.SetBool("isDashed", value); }
    }*/


    public float walkSpeed = 5f;
    public float currentMoveSpeed;
    private float dashCooldown=.5f;
    public float thrust;
    private float dashForce = 1;
    private float dashTime=0.1f;

    [SerializeField]
    private bool isAttacked;
    private bool _isfacingright = true;
    public bool IsFacingRight
    {
        get { return _isfacingright; }
        private set
        {

            if (_isfacingright != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isfacingright = value;

        }
    }

    private bool _isMoving;
    public bool IsMoving 
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
          //  animator.SetBool("isMoving", value);
        } 
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            //Face the right 
            IsFacingRight = true;

        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //facinf the left
            IsFacingRight = false;
        }
    }

    private void Awake()
    {
        damageable = GetComponent<Damageble>();
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
      //  animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        /*if(!damageable.lockVelocity)
          rb.velocity = new Vector2(moveInput.x * walkSpeed * dashForce, rb.velocity.y);
            */


        /* if (isAttacked && touchingDirections.isGround)
         {
         rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
         }*/

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    /*public void isAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("isAttacked");
            isAttacked = true;
        }
        if (context.canceled)
        {
            isAttacked = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && touchingDirections.isGround)
        {
            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);

        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        
        if(context.started && !canDash)
        {
            dashForce = 5;
            StartCoroutine("DashCooldown");
            StartCoroutine("DashTime");
        }
    }*/

    IEnumerator DashTime()
    {
        canDash = true;
      //  isDashed = true;
        yield return new WaitForSeconds(dashTime);
      //  isDashed = false;
        dashForce = 1;

    }


    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash=false;
        
    }
    public void OnHit(Vector2 knockBack)
    {
        
        rb.velocity = new Vector2(knockBack.x, knockBack.y);
    }
}
