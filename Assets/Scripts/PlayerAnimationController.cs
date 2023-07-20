using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private float _horizontalMove;
    private bool _isGround;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");

        if (_horizontalMove != 0) 
        {
            _animator.SetBool("isMove", true);
        }
        else
        {
            _animator.SetBool("isMove", false);
        }

        if (_isGround)
        {
            _animator.SetBool("isJump", false);
        }
        else
        {
            _animator.SetBool("isJump", true);
        }
    }

    public void JumpEnable()
    {
        _isGround = false;
    }

    public void JumpDisable()
    {
        _isGround = true;
    }
}
