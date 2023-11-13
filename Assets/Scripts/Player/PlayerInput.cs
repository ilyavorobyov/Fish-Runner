using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _mover.TryMoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _mover.TryMoveDown();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            _mover.TryMoveRight();
        }

        if( Input.GetKeyDown(KeyCode.A))
        {
            _mover.TryMoveLeft();
        }
    }
}
