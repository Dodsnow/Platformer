using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMeleeAttack : MonoBehaviour
{
    public GameObject player;
    public MonsterMovement monsterMovement;
    public int attackDamage;
    public bool isAttacking = false;


    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
            Attack(hit.gameObject);
        }

        isAttacking = false;
    }

    void Attack(GameObject player)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }
}