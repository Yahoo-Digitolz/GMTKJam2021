using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private Transform _downPosition;
    [SerializeField] private Transform _upPosition;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;
    


    private void Awake()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isElevatorON)
        {
            StartElevator();
        }
    }

    private void StartElevator()
    {
        if (_transform.position.y <= _downPosition.position.y)
        {
            _isElevatorDown = true;
        }
        else if (_transform.position.y >= _upPosition.position.y)
        {
            _isElevatorDown = true;
        }

        if (_isElevatorDown)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _upPosition.position, _speed * Time.deltaTime);
        }
        else
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _downPosition.position, _speed * Time.deltaTime);
        }
    }

    public void ActivateElevator()
    {
        _isElevatorON = !_isElevatorON;
        _animator.SetBool("DoorsClosed", _isElevatorON);
    }

    private Transform _transform;
    private bool _isElevatorDown;
    private bool _isElevatorON;

}
