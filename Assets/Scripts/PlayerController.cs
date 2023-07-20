using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private UnityEvent _jumped;
    [SerializeField] private UnityEvent _landed;

    private Rigidbody2D _rigidbody;
    private float _horizontalMove;
    private float _rayDistance = 0.6f;
    private bool _isFacingRight = true;
    private bool _isGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));

        if (hit.collider)
        {
            _isGround = true;
            _landed?.Invoke();
        }
        else
        {
            _isGround = false;
            _jumped?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGround) 
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }

        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;

        if (_horizontalMove < 0 && _isFacingRight)
            FlipFace();

        if (_horizontalMove > 0 && !_isFacingRight)
            FlipFace();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
    }

    private void FlipFace()
    {
        int velocityFlip = -1;
        _isFacingRight = !_isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= velocityFlip;
        transform.localScale = scale;
    }
}
