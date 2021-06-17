using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverController : MonoBehaviour
{

    //[SerializeField] private WeightManager _weightManager;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _onActivate;

    public bool IsActive { get; private set; }
    public bool CanActivate { get; private set; }

    private void Update()
    {
        if (CanActivate && _inputManager._playerInteraction)
        {
            if (!IsActive)
            {
                LeverActivate(true);
                return;
            }
            //else // décommenter si on veut pouvoir désactiver le levier
            //{
            //    LeverActivate(false);
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") /*&& _weightManager.!_hasObject*/)
        {
            CanActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanActivate = false;
        }
    }

    private void LeverActivate(bool active)
    {
        IsActive = active;
        _onActivate.Invoke();
        AnimatorPropActivate(active);
    }

    public void AnimatorPropActivate(bool enabled)
    {
        if (enabled == true)
        {
            _animator.SetTrigger("ON");
        }
        else
        {
            return;
            //_animator.SetTrigger("OFF");
        }
    }
}
