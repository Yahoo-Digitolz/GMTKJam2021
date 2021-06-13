using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    [SerializeField] GameObject _connectedAbove, _connectedBelow;

    private void Start()
    {
        _connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;

        RopeSegment aboveSegment = _connectedAbove.GetComponent<RopeSegment>();

        if(aboveSegment != null)
        {
            aboveSegment._connectedBelow = gameObject;
            float spriteBottom = _connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
