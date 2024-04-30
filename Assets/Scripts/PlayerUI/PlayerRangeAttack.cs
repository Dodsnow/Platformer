using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    private Controls _controls;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform fireballHole;
    [SerializeField] private float force = 400;

    private void Awake()
    {
        _controls = new Controls();
        _controls.Enable();
        _controls.Player.Fire.performed += ctx => Fire();
    }


    void Fire()
    {
        GameObject go = Instantiate(fireball, fireballHole.position, fireball.transform.rotation);
        if (GetComponent<CharacterFoxAnimation>().isFacingRight)
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            _sprite.flipX = true;
            _audioSource.Play();
        }

        else
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            _sprite.flipX = false;
            _audioSource.Play();
        }
    }

  
}