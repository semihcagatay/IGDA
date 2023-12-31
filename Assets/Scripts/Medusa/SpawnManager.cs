using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Rigidbody2D rb;
    MedusaManager medusaManager;
    public float thrust=0.8f;
    Damageble damagable;
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.left * thrust, ForceMode2D.Impulse);      
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHit = true;
        }
        Destroy(gameObject);
    }
}
