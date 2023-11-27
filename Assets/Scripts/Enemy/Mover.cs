using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private Vector3 _startRotation;

    private void Awake()
    {
        Quaternion rotation = Quaternion.Euler(_startRotation);
        transform.rotation = rotation;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }
}