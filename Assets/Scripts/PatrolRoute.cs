using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class PatrolRoute : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private float _speed = 1;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _routepoints;
    private int _currentPoint;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _routepoints = new Transform[_route.childCount];

        for (int i = 0; i < _routepoints.Length; i++)
        {
            _routepoints[i] = _route.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _routepoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        Flip();

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _routepoints.Length)
                _currentPoint = 0;
        }
    }

    private void Flip()
    {
        var direction = transform.position - _routepoints[_currentPoint].position;
        float defaultPosition = 0.0f;

        if (direction.x > defaultPosition)
        {
            _spriteRenderer.flipX = true;
        }

        if (direction.x < defaultPosition)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
