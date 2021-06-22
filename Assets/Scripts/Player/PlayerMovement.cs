using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region --- Champs de l'inspector ---
    [SerializeField] 
    private AnimationController _animationController;
    [SerializeField] 
    private Rigidbody2D _rb;
    [Space]
    [SerializeField] 
    private Transform _topLeft;
    [SerializeField] 
    private Transform _bottomRight;
    [Space]
    [SerializeField] 
    private LayerMask _whatIsGround;
    [Space]
    public float _movementSpeed;
    public float _jumpForce;
    [Range(0, 3)]
    public int _extraJumps;
    [Space]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _itemClip;
    #endregion

    #region --- Méthodes Publiques ---
    /// <summary>
    /// retourne la vitesse horizontale du rigidbody
    /// </summary>
    public float GetHorizontalSpeed()
    {
        return _rb.velocity.x;
    }

    /// <summary>
    /// retourne la vitesse verticale du rigidbody
    /// </summary>
    public float GetVerticalSpeed()
    {
        return _rb.velocity.y;
    }

    /// <summary>
    /// verifie que le personnage est au sol
    /// </summary>
    public bool IsGrounded()
    {
        #region + Grouncheck avec Raycasts +
        // dans le player, gameobject vide "groundcheck"
        // avec 3 emptys : checkLeft, checkMiddle et checkRight (mieux avec overlapArea)
        //[SerializeField] private float _checkDistance;
        //[SerializeField] private LayerMask _whatIsGround;
        //[SerializeField] private Transform _topLeft et _bottomRight (area)
        //Ray2D ray = new Ray2D(transform.position, Vector2.down);
        //RaycastHit2D hitLeft = Physics2D.Raycast(checkLeft.position, Vector2.down);
        //RaycastHit2D hitMiddle = Physics2D.Raycast(checkMiddle.position, Vector2.down);
        //RaycastHit2D hitRight = Physics2D.Raycast(checkRight.position, Vector2.down);
        #endregion

        Collider2D collider = Physics2D.OverlapArea(_topLeft.position, _bottomRight.position, _whatIsGround);
        return collider != null;
    }
    #endregion

    #region Init
    private void Awake()
    {
        _weightManager = GetComponent<WeightManager>();
        _inputManager = GetComponent<InputManager>();
    }
    #endregion
    // Update is called once per frame
    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal"); // récupère l'axe horizontal
        _direction = Vector2.right * _horizontalInput;
        FlipPlayer();
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _isJumpTrigger = true;
        }
        
            _animationController.AnimatorVelocityY(GetVerticalSpeed());
        
            _animationController.AnimatorExitJump(IsGrounded());
    }

    private void FixedUpdate()
    {
        if (_inputManager._isMoving)
        {
            PlayerRun();
            _animationController.AnimatorWalk(true);
        }
        else
        {
            _animationController.AnimatorWalk(false);
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        
        if (_isJumpTrigger && IsGrounded())
        {
            PlayerJump();
        }
    }

    #region --- Collisions ---
    // parenter le player quand il pose les pieds sur une plateforme mobile
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
        {
            transform.SetParent(collision.transform);
        }
    }
    // dé-parenter le player quand il quitte la plateforme mobile
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
        {
            transform.SetParent(null);
        }
    }
    // ramasser un item en passant dessus et incrémente le score
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Item"))
    //    {
    //        Destroy(other.gameObject);
    //        _audioSource.PlayOneShot(_itemClip);
    //    }
    //}
    #endregion

    #region --- Gizmos ---
    // dessiner la taille du groundchecker avec des gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector2 topleft = _topLeft.position;
        Vector2 topright = new Vector2(_bottomRight.position.x, _topLeft.position.y);
        Vector2 bottomleft = new Vector2(_topLeft.position.x, _bottomRight.position.y);
        Vector2 bottomright = _bottomRight.position;

        Gizmos.DrawLine(topleft, bottomleft);
        Gizmos.DrawLine(topleft, topright);
        Gizmos.DrawLine(bottomleft, bottomright);
        Gizmos.DrawLine(topright, bottomright);
    }
    #endregion

    #region --- Méthodes Privées ---
    // Méthode pour la course du personnage
    private void PlayerRun()
    {
        Vector2 velocity = _direction * _movementSpeed;
        velocity.y = GetVerticalSpeed();
        _rb.velocity = velocity;
    }

    // Méthode pour le saut du personnage
    private void PlayerJump()
    {
        Vector2 velocity = Vector2.up * _jumpForce;
        velocity.x = GetHorizontalSpeed();
        _isJumpTrigger = false;
        _rb.velocity = velocity;
    }

    // retourner le joueur sur l'axe y quand on change de direction
    private void FlipPlayer()
    {
        if (_weightManager._canMove)
        {
            if (_horizontalInput > 0.01f || _horizontalInput < -0.01f)
            {
                transform.right = _direction;
            }
        }
    }
    #endregion

    private Vector2 _direction;
    private float _horizontalInput;
    private int _jumps;
    private bool _isJumpTrigger;
    private bool _isJumping;
    private WeightManager _weightManager;
    private InputManager _inputManager;
}