
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickUpType
    {
        Gem,
        Key,
        RewindPotion,
        HealthPotion,
        
    }
    public PickUpType type;
}
