using System;
using UnityEngine;
using Enum;

public class Fireball : MonoBehaviour
{
  private LiveObjects.RewindableType rewindableObject;

  private void Awake()
  {
    rewindableObject = LiveObjects.RewindableType.Bullet;
  }

  private void OnCollisionEnter2D(Collision2D hit)
  {
    if (hit.gameObject.CompareTag("Enemy"))
    {
     DamageEnemy(hit);
     Destroy(gameObject);
    }
    else
    {
      Destroy(gameObject, 1.5f );
    }
  }
  
  void DamageEnemy(Collision2D hit)
  {
    hit.gameObject.GetComponent<MonsterLife>().TakeDamage(5);
  }

  
}
