using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using AnimationState = Enum.AnimationState;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterFoxAnimation : MonoBehaviour
{
    public Animator animator;
    private PlayerMovement _playerMovement;
    public bool isFacingRight = true;
    private PlayerHealth _playerHealth;
    private AnimationState state;
 


    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        UpdateAnimationStateMovement();
        UpdateAnimationStateJump();
        UpdateAnimationStateHurt();

    }

    private void LateUpdate()
    {
        UpdateAnimationStateDeath();
    }

    void UpdateAnimationStateMovement()
    {
        if (_playerMovement.isMoving == false)
        {
            state = AnimationState.Idle;
        }
        else
        {
            state = AnimationState.Running;
            if (_playerMovement.rb.velocity.x >= 0.1f ^ isFacingRight)
            {
                Flip();
            }
        }
    }

    void UpdateAnimationStateJump()
    {
        if (_playerMovement.rb.velocity.y > .1f)
        {
            state = AnimationState.Jumping;
        }

        if (_playerMovement.rb.velocity.y < -.1f)
        {
            state = AnimationState.Falling;
        }

        animator.SetInteger("state", (int)state);
    }

    void UpdateAnimationStateDeath()
    {
        if (_playerHealth.isDead)
        {
            animator.SetTrigger("Death");
        }
    }

    void UpdateAnimationStateHurt()
    {
        if (_playerHealth.isHurt)
        {
            animator.SetTrigger("Hurt");
            _playerHealth.isHurt = false;
        }
    }


    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

}