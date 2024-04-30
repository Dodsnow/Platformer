using System;
using UnityEngine;

namespace Enum
{
    public class LiveObjects : MonoBehaviour
    {
       
        public enum RewindableType
        {
           Player,
           Enemy,
           Bullet,
           Platform,
           Door,
           Trap,
           Collectable,
        }

        
    }
}