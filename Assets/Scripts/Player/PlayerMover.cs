using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private Vector3 _targetPosition;
    private float _playerRotationY;

    private void Awake()
    {
        _targetPosition = transform.position;
        _playerRotationY = 0;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            Move();
        }

        if(transform.position == _targetPosition)
        {
            Rotate(yAngle: 0);
        }
    }

    public void TryMoveUp()
    {
        if(_targetPosition.y < _maxHeight)
        {
            SetNextPositionY(+_stepSize, _zRotationAngle);
        }
    }

    public void TryMoveDown()
    {
        if(_targetPosition.y > _minHeight)
        {
            SetNextPositionY(-_stepSize, -_zRotationAngle);
        }
    }

    public void TryMoveLeft()
    {
        if(_targetPosition.x > _minPosX)
        {
            SetNextPositionX(-_stepSize, _yRotationAngle);
        }
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _maxPosX)
        {
            SetNextPositionX(_stepSize,0);
        }
    }

    private void SetNextPositionY(float stepSize, float zRotationAngle)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
        Rotate(yAngle: _playerRotationY, zAngle:zRotationAngle);
    }

    private void SetNextPositionX(float stepSize, float rotationAngle)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
        _playerRotationY = rotationAngle;
        Rotate(yAngle: _playerRotationY);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _targetPosition, 
            _moveSpeed * Time.deltaTime);
    }

    private void Rotate(float xAngle = 0, float yAngle = 0,float zAngle = 0)
    {
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
        transform.rotation = rotation;
    }
}
