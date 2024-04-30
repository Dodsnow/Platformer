using System;
using System.Diagnostics;
using UnityEngine.InputSystem;
using UnityEngine;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Controls _controls;
    private bool isGrounded = true;
    private int numberOfJumps = 0;
    public Rigidbody2D rb;
    public bool isMoving = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float speed = 15f;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private LayerMask jumpableGround;


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _controls = new Controls();
        _controls.Player.Move.Enable();
        _controls.Player.Jump.Enable();
        _controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        _controls.Player.Jump.performed += ctx => DoubleJump();
    }

    void FixedUpdate()
    {
        Move(direction: _controls.Player.Move.ReadValue<Vector2>());
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, jumpableGround);
        if (isGrounded)
        {
            numberOfJumps = 0;
        }
    }

    private void Move(Vector2 direction) //This function implements player movement. Parametres required: Vector2 direction. No parametres returns.
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        if (direction.x != 0)
        {
            isMoving = true;
        // Debug.Log("I am moving");
        }
        else
        {
            isMoving = false;
        }
    }


    public void DoubleJump() //This function implements player Double jump. No parametres required, no parametres returns.
    {
        // Debug.Log("I am jumping");
        if (numberOfJumps >= 1) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        numberOfJumps++;
        jumpSoundEffect.Play();
    }
}