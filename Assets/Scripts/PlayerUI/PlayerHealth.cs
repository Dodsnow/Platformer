using Enum;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerHealth : MonoBehaviour
{
  
    public int maxHealth = 10;
    public int _currentHealth;
    private Rigidbody2D _rigidbody2D;
    public HealthBar healthBar;
    public GameObject player;
    public bool isDead = false;
    public bool isHurt = false;

    private void Awake()
    {
      
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        
        if (_currentHealth <= 0)
        {
            Die();
            Invoke(nameof(RestartLevel), 3f);
        }
    }

    public void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag(Tags.Trap))
        {
            TakeDamage(1);
        }

        if (hit.gameObject.CompareTag(Tags.Spikes))
        {
            KillTrapDamage(_currentHealth);
            
        }
    }

    void Die()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        player.GetComponent<BoxCollider2D>().enabled = false;
        isDead = true; 
        
    }

    public void TakeDamage(int damage)
    {
        
        _currentHealth -= damage;
        healthBar.SetHeatlh(_currentHealth);
        isHurt = true;
    }
    
    public void KillTrapDamage(int damage)
    {
        _currentHealth -= damage;
        healthBar.SetHeatlh(_currentHealth);
        
    }

    public void RestartLevel() // Event that happens after animation 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}