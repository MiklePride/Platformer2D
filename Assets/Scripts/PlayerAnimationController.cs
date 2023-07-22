using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimationController : MonoBehaviour
{
    private int _isMoveId = Animator.StringToHash("isMove");
    private int _isJumpId = Animator.StringToHash("isJump");

    private Animator _animator;
    private float _horizontalMove;
    private bool _isGround;
    private bool _isMoving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _isMoving = _horizontalMove != 0;

        _animator.SetBool(_isMoveId, _isMoving);
        _animator.SetBool(_isJumpId, !_isGround);
    }

    public void Jump()
    {
        _isGround = false;
    }

    public void Land()
    {
        _isGround = true;
    }
}
