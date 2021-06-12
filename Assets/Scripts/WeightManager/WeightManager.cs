using UnityEngine;

#region Each objects weight
public enum Weights
{
    LIGHT,
    MEDIUM,
    HEAVY,
}
#endregion


public class WeightManager : MonoBehaviour
{
    #region In Inspector
    public Transform _playerTransform;

    #endregion
    #region Init
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }
    #endregion
    #region Methods

    #region Update
    private void Update()
    {
        HasObject();
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightWeight"))
        {
            _objectCollidedWith = collision;
            ObjectWeightCompare(Weights.LIGHT);
            return;
        }

        else if (collision.gameObject.CompareTag("MediumWeight"))
        {
            _objectCollidedWith = collision;
            ObjectWeightCompare(Weights.MEDIUM);
            return;
        }

        else if (collision.CompareTag("HeavyWeight"))
        {
            _objectCollidedWith = collision;
            ObjectWeightCompare(Weights.HEAVY);
            return;
        }

    }

    public void ObjectWeightCompare(Weights weight)
    {
        switch (weight)
        {
            case Weights.LIGHT:
                {
                    _objectCollidedWith.gameObject.transform.SetParent(_playerTransform);
                    break;
                }
            case Weights.MEDIUM:
                {
                    _playerTransform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    break;
                }
            case Weights.HEAVY:
                {
                    // nor the player and the boss can catch the object
                    break;
                }
            default:
                break;
        }

    }

    public void HasObject()
    {
        if(_inputManager._playerInteraction && !_hasObject)
        {
            _hasObject = true;
            return;
        }

        if(_inputManager._playerInteraction && _hasObject)
        {
            _hasObject = false;
        }

        Debug.Log($"Players hands are full {_hasObject}");
    }
    #endregion

    #region Private
    private Collider2D _objectCollidedWith;
    private InputManager _inputManager;
    private bool _hasObject;
    #endregion
}
