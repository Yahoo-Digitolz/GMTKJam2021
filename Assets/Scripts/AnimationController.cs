using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public PlayerMovement _playerMovement;
    [SerializeField] private LayerMask _whatIsGround;

    /// <summary>
    /// Active ou désactive le booléen du jump dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorJump(bool enabled)
    {
        _animator.SetBool("IsJumping", enabled);
    }

    /// <summary>
    /// Active ou désactive le booléen de la marche dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorWalk(bool enabled)
    {
        _animator.SetBool("IsWalking", enabled);
    }

    /// <summary>
    /// Active ou désactive le booléen du mode berserk du Boss dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorBerserk(bool enabled)
    {
        _animator.SetBool("IsBerserk", enabled);
    }

    /// <summary>
    /// Active ou désactive le booléen du mode "attraper" du Player dans l'animator
    /// </summary>
    /// <param name="enabled">true ou false</param>
    public void AnimatorEnterCatch(bool enabled)
    {
        _animator.SetBool("IsCatching", enabled);
    }


    /// <summary>
    /// Envoie les données de vélocité Y du saut du Player dans l'animator
    /// </summary>
    /// <param name="velocityY">vélocité Y du RigidBody pendant le Saut</param>
    public void AnimatorVelocityY(float velocityY)
    {
        _animator.SetFloat("VelocityY", velocityY);
    }

}
