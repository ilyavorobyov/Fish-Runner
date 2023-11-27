using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _minPosX;
    [SerializeField] private float _maxPosX;
    [SerializeField] private float _zRotationAngle;
    [SerializeField] private float _yRotationAngle;

    private PlayerInput _playerInput;
    private float _noRotationValue = 0;
    private Vector3 _targetPosition;
    private float _playerRotationY;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.MoveUp.performed += ctx => OnTryMoveUp();
        _playerInput.Player.MoveDown.performed += ctx => OnTryMoveDown();
        _playerInput.Player.MoveLeft.performed += ctx => OnTryMoveLeft();
        _playerInput.Player.MoveRight.performed += ctx => OnTryMoveRight();
        _targetPosition = transform.position;
        _playerRotationY = _noRotationValue;
    }

    private void OnEnable()
    {
        _playerInput.Enable();    }

    private void OnDisable()
    {
        _playerInput.Disable();    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            Move();
        }

        if (transform.position == _targetPosition)
        {
            Rotate(yAngle: _noRotationValue);
        }
    }

    private void OnTryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
        {
            SetNextPositionY(+_stepSize, _zRotationAngle);
        }
    }

    private void OnTryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
        {
            SetNextPositionY(-_stepSize, -_zRotationAngle);
        }
    }

    private void OnTryMoveLeft()
    {
        if (_targetPosition.x > _minPosX)
        {
            SetNextPositionX(-_stepSize, _yRotationAngle);
        }
    }

    private void OnTryMoveRight()
    {
        if (_targetPosition.x < _maxPosX)
        {
            SetNextPositionX(_stepSize, _noRotationValue);
        }
    }

    private void SetNextPositionY(float stepSize, float zRotationAngle)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
        Rotate(yAngle: _playerRotationY, zAngle: zRotationAngle);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition,
            _moveSpeed * Time.deltaTime);
    }

    private void SetNextPositionX(float stepSize, float rotationAngle)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
        _playerRotationY = rotationAngle;
        Rotate(yAngle: _playerRotationY);
        _playerRotationY = _noRotationValue;
    }

    private void Rotate(float xAngle = 0, float yAngle = 0, float zAngle = 0)
    {
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
        transform.rotation = rotation;
    }
}