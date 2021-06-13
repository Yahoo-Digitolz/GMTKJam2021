using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public PlayerMovement _playerMovement;
    [SerializeField] private LayerMask _whatIsGround;

    /// <summary>
    /// Active ou d?sactive le bool?en du jump dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorJump(bool enabled)
    {
        _animator.SetBool("IsJumping", enabled);
    }

    /// <summary>
    /// Active ou d?sactive le bool?en de la marche dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorWalk(bool enabled)
    {
        _animator.SetBool("IsWalking", enabled);
    }

    /// <summary>
    /// Active ou d?sactive le bool?en du mode berserk du Boss dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorBerserk(bool enabled)
    {
        _animator.SetBool("IsBerserk", enabled);
    }

    /// <summary>
    /// Active ou d?sactive le bool?en du mode "attraper" du Player dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorEnterCatch(bool enabled)
    {
        _animator.SetBool("IsCatching", enabled);
    }

    /// <summary>
    /// Active ou d?sactive le bool?en du mode "sauf" du Player dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorExitJump(bool enabled)
    {
        _animator.SetBool("IsGrounded", enabled);
    }


    /// <summary>
    /// Envoie les donn?es de v?locit? Y du saut du Player dans l'animator
    /// </summary>
    /// <param name="velocityY">v?locit? Y du RigidBody pendant le Saut</param>
    public void AnimatorVelocityY(float velocityY)
    {
        _animator.SetFloat("VelocityY", velocityY);
    }

    #region Private
    #endregion
}
