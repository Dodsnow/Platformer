using Enum;
using UnityEngine;
using AnimationState = Enum.AnimationState;

namespace Enemy
{
    public class MonsterAnimation : MonoBehaviour
    {
        public Animator _animator;
        private MonsterMovement _monsterMovement;
        private MonsterLife _monsterLife;
        private AnimationState state;
        private bool isFacingRight = true;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _monsterMovement = GetComponent<MonsterMovement>();
        }

        private void FixedUpdate()
        {
            UpdateAnimationState();
            // UpdateAnimationStateDeath();
        }

        void UpdateAnimationState()
        {
            if (_monsterMovement.movementDirection == 0)
            {
                state = AnimationState.Idle;
            }
            else
            {
                state = AnimationState.Running;
                if (_monsterMovement.movementDirection > 0 ^ isFacingRight)
                {
                    Flip();
                }
            }

            _animator.SetInteger("state", (int)state);
        }

        // void UpdateAnimationStateDeath()
        // {
        //     Debug.LogError("Monster is Dead");
        //     if (_monsterLife.isDead)
        //     {
        //         _animator.SetBool("isDead", true);
        //         Debug.Log("Monster Death Animation");
        //     }
        // }


        void Flip()
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}