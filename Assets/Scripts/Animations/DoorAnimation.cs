using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    [ContextMenu("Open")]
    public void Open()
    {
        _animator.SetTrigger("Open");
    }
}