using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int gem = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gem++;
            Debug.Log("Gem:" + gem);
        }
    }
}
