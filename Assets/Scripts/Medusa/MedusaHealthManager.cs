using UnityEngine;

public class MedusaHealthManager : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 200;
    [SerializeField]
    public int currentHealth;
    public MedusaHeathBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

 
}
