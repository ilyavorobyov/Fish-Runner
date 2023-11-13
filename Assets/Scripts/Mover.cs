using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] private float _increaseCount;

    [SerializeField] private float _defaultSpeed;

    private void Awake()
    {
        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        transform.rotation = rotation;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

}
