using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] Rigidbody2D _hook;
    [SerializeField] GameObject[] _prefabRopeSegs;
    [SerializeField] int _numLinks = 5;
    [SerializeField] ALinkToTheFool _aLinkToTheFool;
    [SerializeField] float _maxDistanceBetweenRopeChunk;

    private void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody2D prevBod = _hook;

        for(int i = 0; i < _numLinks; i++)
        {
            int index = Random.Range(0, _prefabRopeSegs.Length);
            GameObject newSeg = Instantiate(_prefabRopeSegs[index]);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hingeJoint = newSeg.GetComponent<HingeJoint2D>();
            SpringJoint2D distanceJoint = newSeg.GetComponent<SpringJoint2D>();
            hingeJoint.connectedBody = prevBod;
            distanceJoint.connectedBody = prevBod;

            

            if(i < _numLinks - 1)
            {
                prevBod = newSeg.GetComponent<Rigidbody2D>();
            }
            else
            {
                _aLinkToTheFool.ConnectRopeEnd(prevBod.GetComponent<Rigidbody2D>());
            }

            
        }
    }
}
