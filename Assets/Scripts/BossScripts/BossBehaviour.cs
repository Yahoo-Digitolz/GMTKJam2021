using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    #region Show In Inspector

    [SerializeField] private float _speed;
    [SerializeField] private AnimationController _animatorController;

    [Header("Detections")]
    [SerializeField] private Transform _wallDetection;
    [SerializeField] private float _wallDetectionDistance;
    [SerializeField] private LayerMask _whatIsWall;

    #endregion

    #region Private Variables

    private Rigidbody2D _bossRb;
    private float _direction = 1;
    private RaycastHit2D[] _wallDetectionBuffer = new RaycastHit2D[1];

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _bossRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DoWander();
    }

    #endregion

    #region Private Methods

    private void DoWander()
    {
        _bossRb.velocity = new Vector2(_direction * _speed, _bossRb.velocity.y);

        if (WallDetected())
        {
            if (_bossRb.velocity.x > 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _direction = -1;
            }

            else if(_bossRb.velocity.x < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _direction = 1;
            }
        }
        _animatorController.AnimatorWalk(true);
    }

    private bool WallDetected()
    {
        int wallInfo = Physics2D.RaycastNonAlloc(_wallDetection.position, transform.InverseTransformVector(Vector2.right), _wallDetectionBuffer, _wallDetectionDistance, _whatIsWall);
        return wallInfo > 0;
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(_wallDetection.position, transform.InverseTransformVector(Vector2.right) * _wallDetectionDistance);
    }
}
