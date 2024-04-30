using System;
using System.Collections;
using Enum;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(EdgeCollider2D))]
public class MonsterLife : MonoBehaviour
{
    
    public int maxHealth = 10;
    public int currentHealth;
    private Animator _animator;
    public bool isDead = false;
    public EdgeCollider2D edgeCollider2D;
    public Rigidbody2D rb;
    private static readonly int Death = Animator.StringToHash("Death");


    private void Awake()
    {
        
        currentHealth = maxHealth;
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }


 

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            edgeCollider2D.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            isDead = true;
            Destroy(gameObject, 0.6f);
        }
    }

   
}