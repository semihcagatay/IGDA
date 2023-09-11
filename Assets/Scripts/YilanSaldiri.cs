
using UnityEngine;

public class YilanSaldiri : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D attackCollider;
    public int attackDMG = 3;

    public Vector2 knockBack = Vector2.zero;
    public Vector2 knockBackReveerse = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageble damageble = other.GetComponent<Damageble>();
        if (damageble != null)
        {
            Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockBack : knockBackReveerse;
            damageble.lockVelocity = true;
            bool getHit = damageble.Hit(attackDMG, deliveredKnockBack);
            if (getHit)
            {

                Debug.Log(other.name + "hit for" + attackDMG);
            }
        }
    }
    /*private void OnTriggerExit2D(Collider2D other)
    {
        Damageble damageble = other.GetComponent<Damageble>();  
        damageble.lockVelocity = false;
    }*/
}
