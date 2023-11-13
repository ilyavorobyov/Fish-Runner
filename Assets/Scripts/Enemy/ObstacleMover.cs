using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : Mover
{
    private void Awake()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = rotation;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector3(-1, -1, 0) * _speed * Time.deltaTime);
    }
}
