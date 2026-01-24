using UnityEngine;    //This script manages taking damage, and should include enemy specific things, ex. Health values, VFX, etc.

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 20;
    [SerializeField] private float currentHealth;
    private Rigidbody2D rb;
    void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
   
    public void TakeDamage(DamageInfo damage)
    {
        currentHealth -= damage.amount;
        rb.linearVelocityX += damage.knockBackX;
        rb.linearVelocityY += damage.knockBackY;
        
        if (currentHealth <= 0)
        {
            Die();
        }

    }
    
    private void Die()
    {
        Destroy(gameObject); 
    }

}
