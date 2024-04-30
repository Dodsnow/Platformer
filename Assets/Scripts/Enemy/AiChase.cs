using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public Transform lineOfSight;
    private bool targetInRange = false;
    
    public bool isChasing = false;

    

    public void CheckForTarget()
    {
       targetInRange = Physics2D.OverlapCircle(lineOfSight.position, 2f, player.GetComponent<Collision2D>().gameObject.layer);
       
    }

    public void ChaseTarget()
    {
        if (targetInRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
    }
    
}