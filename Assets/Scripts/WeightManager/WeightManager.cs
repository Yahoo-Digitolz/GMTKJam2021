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
    public bool _canMove { get; private set; }
    [SerializeField] private LayerMask _obstacleLayer;
    #endregion

    #region Init
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _canMove = true;
    }
    #endregion

    #region Update
    private void Update()
    {
        //HasObject();

        if (_objectCollidedWith != null && _objectCollidedWith.CompareTag("LightWeight") && !_hasObject && _inputManager._playerInteraction)
        {
            LiftObject(Weights.LIGHT);
            return;
        }

        if (_objectCollidedWith != null && _objectCollidedWith.CompareTag("MediumWeight") && !_hasObject && _inputManager._playerInteraction)
        {
            LiftObject(Weights.MEDIUM);
            return;
        }

        if (_objectCollidedWith != null && _hasObject && _inputManager._playerInteraction)
        {
            AbandonChild();
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (_inputManager._playerInteraction && !_hasObject)
        //{
        //if (collision.gameObject.CompareTag("LightWeight"))
        //{
            _objectCollidedWith = collision;
        //}
            //    //LiftObject(Weights.LIGHT);
            //    //Debug.Log("Players hands are full");
            //    return;
            //}

            //else if (collision.gameObject.CompareTag("MediumWeight"))
            //{
            //    _objectCollidedWith = collision;
            //    //LiftObject(Weights.MEDIUM);
            //    return;
            //}

            //else if (collision.CompareTag("HeavyWeight"))
            //{
            //    _objectCollidedWith = collision;
            //    //LiftObject(Weights.HEAVY);
            //    return;
            //}
        //}

        //else if(_inputManager._playerInteraction && _hasObject)
        //{
        //    Debug.Log("ush");
        //    if (collision.gameObject.CompareTag("LightWeight"))
        //    {
        //        _objectCollidedWith = collision;
        //        DropObject(Weights.LIGHT);
        //        Debug.Log($"Players hands are empty");
        //        return;
        //    }

        //    else if (collision.gameObject.CompareTag("MediumWeight"))
        //    {
        //        _objectCollidedWith = collision;
        //        DropObject(Weights.MEDIUM);
        //        return;
        //    }

        //    else if (collision.CompareTag("HeavyWeight"))
        //    {
        //        _objectCollidedWith = collision;
        //        DropObject(Weights.HEAVY);
        //        return;
        //    }
        //}
    }


    #region Methods

    public void AbandonChild()
    {
        _childs = gameObject.GetComponentsInChildren<Transform>();
        Debug.Log("Kek");

        for (_child = 0; _child <= _childs.Length; _child++)
        {
            if (_childs[_child].CompareTag("LightWeight"))
            {
                //_childs[_child].transform.SetParent(null);
                //_hasObject = false;
                DropObject(Weights.LIGHT);
                return;
            }

            else if (_childs[_child].CompareTag("MediumWeight"))
            {
                //_playerTransform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //_childs[_child].SetParent(null);
                //_canMove = true;
                //_hasObject = false;
                DropObject(Weights.MEDIUM);
                return;
            }
        }
    }

    public void LiftObject(Weights weight)
    {
        switch (weight)
        {
            case Weights.LIGHT:
                {
                    _objectCollidedWith.gameObject.transform.root.SetParent(_playerTransform);
                    _objectCollidedWith.gameObject.GetComponentInParent<Rigidbody2D>().isKinematic = true;
                    _hasObject = true;
                    break;
                }
            case Weights.MEDIUM:
                {
                    _playerTransform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    _objectCollidedWith.gameObject.transform.SetParent(_playerTransform);
                    _hasObject = true;
                    _canMove = false;
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

    public void DropObject(Weights weight)
    {
        switch (weight)
        {
            case Weights.LIGHT:
                {
                    Debug.Log("Drop light object");
                    _childs[_child].transform.SetParent(null);
                    _childs[_child].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    _hasObject = false;
                    break;
                }
            case Weights.MEDIUM:
                {
                    Debug.Log("Drop medium object");
                    _playerTransform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    _childs[_child].transform.SetParent(null);
                    _canMove = true;
                    _hasObject = false;
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

    //public void HasObject()
    //{
    //    if(_inputManager._playerInteraction && _hasObject)
    //    {
    //        _hasObject = false;
    //    }

    //    Debug.Log($"Players hands are full {_hasObject}");
    //}
    #endregion

    #region Private
    private Collider2D _objectCollidedWith;
    private InputManager _inputManager;
    private bool _hasObject;
    private Transform[] _childs;
    private int _child;
    #endregion
}