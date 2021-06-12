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
        _horizontalMovement = Input.GetAxis("Horizontal");
        _jump = Input.GetAxis("Vertical");
        _playerInteraction = Input.GetButton("Use");
        _isJumping = Input.GetKeyDown(KeyCode.Z);
        _isMoving = Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D);
    }
    #endregion
}