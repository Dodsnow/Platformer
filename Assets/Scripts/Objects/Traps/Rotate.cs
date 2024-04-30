using Enum;
using UnityEngine;


public class Rotate : MonoBehaviour
{
    
    [SerializeField] private float speed = 2f;
    
    private void Update() 
    {
        Rotation();
    }

    public bool Rotation() //Saw Trap Rotation function
    {
        transform.Rotate(0,0,360 * speed * Time.deltaTime);
        return true;
    }
}
