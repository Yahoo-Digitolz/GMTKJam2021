using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALinkToTheFool : MonoBehaviour
{
    public void ConnectRopeEnd(Rigidbody2D lastRb)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = lastRb;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = Vector2.zero;
    }
}
