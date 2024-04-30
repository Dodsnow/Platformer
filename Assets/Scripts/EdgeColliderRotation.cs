using UnityEngine;

public class EdgeColliderRotation : MonoBehaviour
{
    private Rigidbody2D _rb;
    private EdgeCollider2D _collider2D;
    private bool isFacingRight = true;
   
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<EdgeCollider2D>();
    }

    
    void FixedUpdate()
    {
        
        if (transform.position.x < 0 ^ !isFacingRight)
        {
           Flip(); 
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.eulerAngles = new Vector3(0, 180,0);
    }
}
