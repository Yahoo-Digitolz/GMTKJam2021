using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region In Inspector
    [Header("Assign player character rigidbody here")]
    public Rigidbody2D _playerRigidbody2D;

    [Header("Movement Settings")]
    public float _playerSpeed;
    [Range(0f, 10f)] public float _jumpStrength;

    [Header("Jump manager")]
    [Range(0f, 10f)] public float _jumpGravity;
    [Range(0f, 10f)] public float _floatingJumpGravity;
    [Range(0f, 10f)] public float _fallGravity;
    public bool _triggerJump;
    public int _jumpAllowed;
    #endregion

    #region Init
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _isOnTheGround = GetComponent<CheckGround>();
    }
    #endregion

    #region Update
    private void Update()
    {
        if (_isOnTheGround.IsOnTheGround())
        {
            _jumpCount = _jumpAllowed;
        }

        JumpInput();
    }
    #endregion

    #region Fixed Update
    private void FixedUpdate()
    {
        PlayerMovement();

        if(!_inputManager._isMoving)
        {
            _playerRigidbody2D.velocity = Vector2.zero;
        }

        //Debug.Log(_inputManager._isMoving);

        if(_isOnTheGround && _inputManager._isJumping)
        {
            DoJump();
        }

        BetterJumps();
        Debug.Log(_playerRigidbody2D.gravityScale);
    }
    #endregion

    #region Methods
    private void PlayerMovement()
    {
        _movementVelocity = new Vector2(_inputManager._horizontalMovement * _playerSpeed, _playerRigidbody2D.velocity.y);
        _playerRigidbody2D.velocity = _movementVelocity;
    }

    public void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnTheGround.IsOnTheGround())
        {
            _triggerJump = true;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && _jumpCount > 0)
        {
            _triggerJump = true;
            _jumpCount--;
        }
    }

    private void DoJump()
    {
        _playerRigidbody2D.velocity = new Vector2(_playerRigidbody2D.velocity.x, _jumpStrength);
        _triggerJump = false;
    }

    private void PlayerInteraction()
    {

    }

    private void BetterJumps()
    {
        if (_playerRigidbody2D.velocity.y >= 0.01f && _playerRigidbody2D.velocity.y < 4f && !_isOnTheGround.IsOnTheGround())
        {
            _playerRigidbody2D.gravityScale = _jumpGravity;
        }
        else if (_playerRigidbody2D.velocity.y > 4f && _playerRigidbody2D.velocity.y < 5f && !_isOnTheGround.IsOnTheGround())
        {
            _playerRigidbody2D.gravityScale = _floatingJumpGravity;
        }
        else if (_playerRigidbody2D.velocity.y <= -0.01f && !_isOnTheGround.IsOnTheGround())
        {
            _playerRigidbody2D.gravityScale = _fallGravity;
        }
    }
    #endregion

    #region Private
    private Vector2 _movementVelocity;

    private InputManager _inputManager;
    private CheckGround _isOnTheGround;

    private int _jumpCount;
    #endregion
}
