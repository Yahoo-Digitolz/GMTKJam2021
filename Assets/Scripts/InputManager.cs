using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Properties
    public float _horizontalMovement { get; set; }
    public float _jump { get; set; }
    public bool _playerInteraction { get; set; }
    public bool _isMoving { get; set; }
    public bool _isJumping { get; set; }
    #endregion

    #region Update
    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _jump = Input.GetAxis("Vertical");
        _playerInteraction = Input.GetButtonDown("Use");
        _isJumping = Input.GetKeyDown(KeyCode.Z);
        _isMoving = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0f;
    }
    #endregion
}