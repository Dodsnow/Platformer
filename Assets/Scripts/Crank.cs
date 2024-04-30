using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Crank : MonoBehaviour
{
     
    [FormerlySerializedAs("door")] [SerializeField] private DoorAnimation doorAnimation;
    [SerializeField] private GameObject player;
    private Animator _animator;
    public bool isOpen = false;
    private DoorAnimation _doorAnimation;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && !isOpen)
        {
            if (!isOpen)
            {
                _animator.SetTrigger("isTouched");
                doorAnimation.Open();
                isOpen = true;
            }
        }
    }
}