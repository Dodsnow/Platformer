
using Unity.VisualScripting;
using UnityEngine;


public class MonsterMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] private float movementRange = 10;
    private AiChase _aiChase;
    private float distance;
    
   
    
    private float startPosition;
    public int movementDirection = -1;


    private Animator _anim;

    private void Awake()
    {
        _aiChase = GetComponent<AiChase>();
           _anim = GetComponent<Animator>();
       
    }
    void Start()
    {
        startPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        if (!_aiChase.isChasing)
        {
            Movement();
        }
        
        else if (_aiChase.isChasing)
        {
            Chasing();
        }
        
    }

    void Chasing()
    {
        distance = Vector2.Distance(transform.position, _aiChase.player.transform.position);
        Vector2 direction = (_aiChase.player.transform.position - transform.position);
        direction.Normalize();
        if (distance < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _aiChase.player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
    void Movement()
    {
        transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime * movementDirection));
        if (transform.position.x < startPosition || transform.position.x > startPosition + movementRange)
        {
            movementDirection *= -1;
        } 
    }
}