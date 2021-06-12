using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField] Transform _topLeftCorner;
    [SerializeField] Transform _botRightCorner;
    [SerializeField] LayerMask _isTheGround;


    private void CheckGroundIsTrue()
    {
        _groundIsTrue = _overlap != null;
        Debug.Log("Collision avec la sol est : " + _groundIsTrue);
    }

    public bool IsOnTheGround()
    {
        return _groundIsTrue;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTheGround();
        CheckGroundIsTrue();
    }

   
    private void CheckTheGround()
    {
        _overlap = Physics2D.OverlapArea(_topLeftCorner.position, _botRightCorner.position, _isTheGround);
    }

    private bool _groundIsTrue;
    private Collider2D _overlap;
}
